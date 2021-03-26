using AdminApprovalBack.Services;
using AdminApprovalBack.Services.SystemManage;
using AdminApprovalBack.Services.SystemSecurity;
using Data.Entity.SystemManage;
using Data.Entity.SystemSecurity;
using Data.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Middleware;
using System;

namespace AdminApprovalBack.Controllers
{
    public class LoginController : Controller
    {
        private readonly VerifyCodeService verifyCodeService;
        private readonly LogApp logApp;
        private readonly UserApp userApp;

        public LoginController(VerifyCodeService verifyCodeService, LogApp logApp,UserApp userApp)
        {
            this.verifyCodeService = verifyCodeService;
            this.logApp = logApp;
            this.userApp = userApp;
        }

        [HttpGet]
        public IActionResult GetAuthCode()
        {
            var vcode = verifyCodeService.GenerateCode();
            Response.Cookies.Append("vcode-session", vcode.token);
            return File(vcode.image, @"image/Gif");
        }
        [HttpGet]
        public IActionResult OutLogin()
        {
            var userInfo = HttpContext.GetUserInformation();
            if (userInfo == null)
            {
                return Json(new { success = true });
            }
            var logEntity = new LogEntity
            {
                F_ModuleName = "系统登录",
                F_Type = DbLogType.Exit.ToString(),
                F_Account = userInfo.Code,
                F_NickName = userInfo.Name,
                F_Result = true,
                F_Description = "安全退出系统",
            };
            logApp.WriteDbLog(logEntity);
            HttpContext.Response.Cookies.Delete("Authorization");
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult CheckLogin(string username, string password, string code)
        {
            LogEntity logEntity = new LogEntity();
            logEntity.F_ModuleName = "系统登录";
            logEntity.F_Type = DbLogType.Login.ToString();
            try
            {
                var vcodeSession = Request.Cookies["vcode-session"];
                if (string.IsNullOrEmpty(vcodeSession))
                {
                    return Json(new { success = false, message = "验证码已失效" });
                }
                var state = verifyCodeService.VerifyCode(vcodeSession, code);
                switch (state)
                {
                    case VerifyCodeService.State.WrongCode: return Json(new { success = false, message = "验证码错误" });
                    case VerifyCodeService.State.Expired: return Json(new { success = false, message = "验证码已过期" });
                    case VerifyCodeService.State.Invalid: return Json(new { success = false, message = "验证信息错误" });
                }

                UserEntity userEntity = userApp.CheckLogin(username, password);

                HttpContext.SetUserInformation(userEntity);
                logEntity.F_Account = userEntity.F_Account;
                logEntity.F_NickName = userEntity.F_RealName;
                logEntity.F_Result = true;
                logEntity.F_Description = "登录成功";
                logApp.WriteDbLog(logEntity);

                return Json(new { success = true, message = "登录成功" });
            }
            catch (Exception ex)
            {
                var msg = "登录失败，" + ex.Message;
                logEntity.F_Account = username;
                logEntity.F_NickName = username;
                logEntity.F_Result = false;
                logEntity.F_Description = msg;
                logApp.WriteDbLog(logEntity);
                return Json(new { success = false, message = msg });
            }
        }
    }
}
