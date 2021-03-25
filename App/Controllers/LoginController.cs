using AdminApprovalBack.Services;
using Data.Entity.SystemManage;
using Data.Entity.SystemSecurity;
using Data.Infrastructure;
using Data.IRepository.SystemSecurity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AdminApprovalBack.Controllers
{
    public class LoginController : Controller
    {
        private readonly VerifyCodeService verifyCodeService;
        private readonly ILogRepository logRepository;

        public LoginController(VerifyCodeService verifyCodeService,ILogRepository logRepository)
        {
            this.verifyCodeService = verifyCodeService;
            this.logRepository = logRepository;
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
            new LogApp().WriteDbLog(new LogEntity
            {
                F_ModuleName = "系统登录",
                F_Type = DbLogType.Exit.ToString(),
                F_Account = OperatorProvider.Provider.GetCurrent().UserCode,
                F_NickName = OperatorProvider.Provider.GetCurrent().UserName,
                F_Result = true,
                F_Description = "安全退出系统",
            });
            Session.Abandon();
            Session.Clear();
            OperatorProvider.Provider.RemoveCurrent();
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

                UserEntity userEntity = new UserApp().CheckLogin(username, password);
                if (userEntity != null)
                {
                    OperatorModel operatorModel = new OperatorModel();
                    operatorModel.UserId = userEntity.F_Id;
                    operatorModel.UserCode = userEntity.F_Account;
                    operatorModel.UserName = userEntity.F_RealName;
                    operatorModel.CompanyId = userEntity.F_OrganizeId;
                    operatorModel.DepartmentId = userEntity.F_DepartmentId;
                    operatorModel.RoleId = userEntity.F_RoleId;
                    operatorModel.LoginIPAddress = Net.Ip;
                    operatorModel.LoginIPAddressName = Net.GetLocation(operatorModel.LoginIPAddress);
                    operatorModel.LoginTime = DateTime.Now;
                    operatorModel.LoginToken = DESEncrypt.Encrypt(Guid.NewGuid().ToString());
                    if (userEntity.F_Account == "admin")
                    {
                        operatorModel.IsSystem = true;
                    }
                    else
                    {
                        operatorModel.IsSystem = false;
                    }
                    OperatorProvider.Provider.AddCurrent(operatorModel);
                    logEntity.F_Account = userEntity.F_Account;
                    logEntity.F_NickName = userEntity.F_RealName;
                    logEntity.F_Result = true;
                    logEntity.F_Description = "登录成功";
                    new LogApp().WriteDbLog(logEntity);
                }
                return Content(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功。" }.ToJson());
            }
            catch (Exception ex)
            {
                logEntity.F_Account = username;
                logEntity.F_NickName = username;
                logEntity.F_Result = false;
                logEntity.F_Description = "登录失败，" + ex.Message;
                new LogApp().WriteDbLog(logEntity);
                return Content(new AjaxResult { state = ResultType.error.ToString(), message = ex.Message }.ToJson());
            }
        }
    }
}
