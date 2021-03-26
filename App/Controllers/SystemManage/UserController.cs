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
        public IActionResult GetGridJson(Pagination pagination, string keyword)
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
        public IActionResult GetFormJson(string keyValue)
        {
            var data = userApp.GetForm(keyValue);
            return Success(data);
        }
        [HttpPost]
        public IActionResult SubmitForm(UserEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue)
        {
            userApp.SubmitForm(userEntity, userLogOnEntity, keyValue);
            return Success();
        }
        [HttpPost]
        [HandlerAuthorize]
        public IActionResult DeleteForm(string keyValue)
        {
            userApp.DeleteForm(keyValue);
            return Success();
        }

        [HttpPost]
        [HandlerAuthorize]
        public IActionResult SubmitRevisePassword(string userPassword, string keyValue)
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
            userApp.UpdateForm(userEntity);
            return Success();
        }
        [HttpPost]
        [HandlerAuthorize]
        public IActionResult EnabledAccount(string keyValue)
        {
            UserEntity userEntity = new UserEntity();
            userEntity.F_Id = keyValue;
            userEntity.F_EnabledMark = true;
            userApp.UpdateForm(userEntity);
            return Success();
        }
    }
}
