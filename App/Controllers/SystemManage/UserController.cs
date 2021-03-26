using AdminApprovalBack.Interceptors;
using AdminApprovalBack.Services.SystemManage;
using Common.Query;
using Data.Entity.SystemManage;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace AdminApprovalBack.Controllers.SystemManage
{
    [Area("SystemManage")]
    public class UserController : ControllerBase
    {
        private readonly UserApp userApp;
        private readonly UserLogOnApp userLogOnApp;

        public UserController(UserApp userApp, UserLogOnApp userLogOnApp)
        {
            this.userApp = userApp;
            this.userLogOnApp = userLogOnApp;
        }
        [HttpGet]
        public IActionResult Index(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = userApp.GetList(pagination, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Success(data);
        }
        [HttpGet]
        public IActionResult One(string keyValue)
        {
            var data = userApp.FineOne(keyValue);
            return Success(data);
        }
        [HttpPost]
        public IActionResult Submit(UserEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue)
        {
            userApp.Submit(userEntity, userLogOnEntity, keyValue);
            return Success();
        }
        [HttpPost]
        [HandlerAuthorize]
        public IActionResult Delete(string keyValue)
        {
            userApp.Delete(keyValue);
            return Success();
        }

        [HttpPost]
        [HandlerAuthorize]
        public IActionResult RevisePassword(string userPassword, string keyValue)
        {
            userLogOnApp.RevisePassword(userPassword, keyValue);
            return Success();
        }
        [HttpPost]
        [HandlerAuthorize]
        public IActionResult DisabledAccount(string keyValue)
        {
            UserEntity userEntity = new UserEntity();
            userEntity.F_Id = keyValue;
            userEntity.F_EnabledMark = false;
            userApp.Update(userEntity);
            return Success();
        }
        [HttpPost]
        [HandlerAuthorize]
        public IActionResult EnabledAccount(string keyValue)
        {
            UserEntity userEntity = new UserEntity();
            userEntity.F_Id = keyValue;
            userEntity.F_EnabledMark = true;
            userApp.Update(userEntity);
            return Success();
        }
    }
}
