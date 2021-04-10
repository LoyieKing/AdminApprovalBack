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
using System.Collections.Generic;
using System.Linq;
using Service;

namespace AdminApprovalBack.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly VerifyCodeService verifyCodeService;
        private readonly LogService logger;
        private readonly UserService userService;
        private readonly RepoService<UserOrganizeEntity> userOrganizeService;
        private readonly RepoService<RoleEntity> roleService;

        public LoginController(VerifyCodeService verifyCodeService,
            LogService logger,
            UserService userApp,
            RepoService<UserOrganizeEntity> userOrganizeService,
            RepoService<RoleEntity> roleService)
        {
            this.verifyCodeService = verifyCodeService;
            this.logger = logger;
            this.userService = userApp;
            this.userOrganizeService = userOrganizeService;
            this.roleService = roleService;
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
                return Json(new {success = true});
            }

            logger.WriteDbLog(DbLogType.Exit.ToString(), true, "安全退出系统");
            HttpContext.Response.Cookies.Delete("Authorization");
            return Success();
        }

        [HttpPost]
        public IActionResult CheckLogin([FromBody] LoginParam param)
        {
            try
            {
                string username = param.Username ?? throwStringAssert("用户名不能为空");
                string password = param.Password ?? throwStringAssert("密码不能为空");
                string code = param.Code ?? throwStringAssert("验证码不能为空");
                var vcodeSession = Request.Cookies["vcode-session"];
                if (string.IsNullOrEmpty(vcodeSession))
                {
                    return Json(new {success = false, message = "验证码已失效"});
                }

                var state = verifyCodeService.VerifyCode(vcodeSession, code);
                switch (state)
                {
                    case VerifyCodeService.State.WrongCode: return Json(new {success = false, message = "验证码错误"});
                    case VerifyCodeService.State.Expired: return Json(new {success = false, message = "验证码已过期"});
                    case VerifyCodeService.State.Invalid: return Json(new {success = false, message = "验证信息错误"});
                }

                UserEntity userEntity = userService.CheckPassword(username, password);

                var orgs = userOrganizeService.IQueryable().Where(it => it.User.Id == userEntity.Id).ToList();
                var roles = roleService
                    .IQueryable().ToList();

                var myroles = roles
                    .Where(it => orgs.Any(org =>
                        it.OrganizeCategoryId == org.Organize.CategoryId && it.OrganizeDutyLevel == org.DutyLevel))
                    .ToList();

                var permissions = new HashSet<string>();
                foreach (var roleEntity in myroles)
                {
                    var menus = roleEntity.AvailableMenus.Split(",", StringSplitOptions.RemoveEmptyEntries);
                    foreach (var menu in menus)
                    {
                        permissions.Add(menu);
                    }
                }

                logger.WriteDbLog(DbLogType.Login.ToString(), true, "登录成功");

                return Json(new
                    {success = true, data = LoginExtension.CreateJwtToken(userEntity, permissions.ToArray())});
            }
            catch (Exception ex)
            {
                var msg = "登录失败，" + ex.Message;
                logger.WriteDbLog(DbLogType.Login.ToString(), false, msg);

                return Json(new {success = false, message = msg});
            }
        }

        public record LoginParam
        {
            public string? Username { get; set; }
            public string? Password { get; set; }
            public string? Code { get; set; }
        }
    }
}