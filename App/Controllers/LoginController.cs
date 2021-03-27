using AdminApprovalBack.Services;
using AdminApprovalBack.Services.SystemManage;
using AdminApprovalBack.Services.SystemSecurity;
using Data.Entity.SystemManage;
using Data.Entity.SystemSecurity;
using Data.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Middleware;
using Service.Login;
using System;

namespace AdminApprovalBack.Controllers
{
    public class LoginController : Controller
    {
        private readonly VerifyCodeService verifyCodeService;
        private readonly LogService logger;
        private readonly UserService userService;

        public LoginController(VerifyCodeService verifyCodeService, LogService logger,UserService userApp)
        {
            this.verifyCodeService = verifyCodeService;
            this.logger = logger;
            this.userService = userApp;
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
            logger.WriteDbLog(DbLogType.Exit.ToString(), true, "安全退出系统");
            HttpContext.Response.Cookies.Delete("Authorization");
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult CheckLogin(string username, string password, string code)
        {
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

                UserEntity userEntity = userService.CheckPassword(username, password);

                HttpContext.SetUserInformation(userEntity);
                logger.WriteDbLog(DbLogType.Login.ToString(), true, "登录成功");

                return Json(new { success = true, message = "登录成功" });
            }
            catch (Exception ex)
            {
                var msg = "登录失败，" + ex.Message;
                logger.WriteDbLog(DbLogType.Login.ToString(), false, msg);

                return Json(new { success = false, message = msg });
            }
        }
    }
}
