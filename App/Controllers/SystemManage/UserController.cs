using AdminApprovalBack.Interceptors;
using AdminApprovalBack.Services.SystemManage;
using Common.Query;
using Data.Entity.SystemManage;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.Login;
using System.Collections.Generic;
using System.Linq;
using AdminApprovalBack.Models;
using Service;


namespace AdminApprovalBack.Controllers.SystemManage
{
    [Area("SystemManage")]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [HandlerAuthorize]
        public IActionResult Index([FromQuery(Name = "pagination")] string page, [FromQuery] string keyword)
        {
            var pagination = JsonConvert.DeserializeObject<Pagination>(page);
            var data = new
            {
                rows = userService.GetList(pagination, keyword).ToList().Select(it => new UserModel().FromEntity(it)),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Success(data);
        }

        [HttpGet]
        public IActionResult One(int id)
        {
            var data = userService.FindOne(id);
            return Success(new UserModel().FromEntity(data));
        }

        [HttpPost]
        public IActionResult Update([FromBody] UserEntity userEntity)
        {
            var userInfo = HttpContext.GetUserInformation();
            var admin = userInfo?.IsAdmin ?? false;

            if (userEntity.Id != userEntity.Id && !admin)
            {
                return Error("权限不足！您只能修改自己的账户信息");
            }

            if (admin)
            {
                if (userEntity.Password != null)
                {
                    userEntity.Password = userService.HashPassword(userEntity.Password);
                }
            }
            else
            {
                userEntity.Password = null!;
            }

            userService.Update(userEntity);
            return Success();
        }

        [HttpPost]
        [HandlerAuthorize]
        public IActionResult Delete([FromQuery] int id)
        {
            userService.Delete(id);
            return Success();
        }

        [HttpPost]
        [HandlerAuthorize]
        public IActionResult Deletes([FromBody] int[] ids)
        {
            using var trans = userService.DbContext.Database.BeginTransaction();
            foreach (var id in ids)
            {
                userService.Delete(id);
            }

            trans.Commit();
            return Success();
        }

        [HttpPost]
        public IActionResult RevisePassword(int id, string oldpwd, string newpwd)
        {
            userService.RevisePassword(id, oldpwd, newpwd);
            return Success();
        }

        [HttpPost]
        [HandlerAuthorize]
        public IActionResult DisabledAccount(int keyValue)
        {
            UserEntity userEntity = new UserEntity();
            userEntity.Id = keyValue;
            userEntity.EnabledMark = false;
            userService.Update(userEntity);
            return Success();
        }

        [HttpPost]
        [HandlerAuthorize]
        public IActionResult EnabledAccount(int keyValue)
        {
            UserEntity userEntity = new UserEntity();
            userEntity.Id = keyValue;
            userEntity.EnabledMark = true;
            userService.Update(userEntity);
            return Success();
        }
    }
}