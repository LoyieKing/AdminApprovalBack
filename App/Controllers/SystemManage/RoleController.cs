using AdminApprovalBack.Interceptors;
using AdminApprovalBack.Services.SystemManage;
using Data.Entity.SystemManage;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AdminApprovalBack.Controllers.SystemManage
{
    [Area("SystemManage")]
    public class RoleController : ControllerBase
    {
        private readonly RoleApp roleApp;
        private readonly RoleAuthorizeApp roleAuthorizeApp;
        private readonly ModuleApp moduleApp;
        private readonly ModuleButtonApp moduleButtonApp;

        public RoleController(ModuleButtonApp moduleButtonApp, ModuleApp moduleApp, RoleAuthorizeApp roleAuthorizeApp, RoleApp roleApp)
        {
            this.moduleButtonApp = moduleButtonApp;
            this.moduleApp = moduleApp;
            this.roleAuthorizeApp = roleAuthorizeApp;
            this.roleApp = roleApp;
        }

        [HttpGet]
        public IActionResult GetGridJson(string keyword)
        {
            var data = roleApp.GetList(keyword);
            return Success(data);
        }
        [HttpGet]
        public IActionResult GetFormJson(string keyValue)
        {
            var data = roleApp.GetForm(keyValue);
            return Success(data);
        }
        [HttpPost]
        public IActionResult SubmitForm(RoleEntity roleEntity, string permissionIds, string keyValue)
        {
            roleApp.SubmitForm(roleEntity, permissionIds.Split(','), keyValue);
            return Success();
        }
        [HttpPost]
        [HandlerAuthorize]
        public IActionResult DeleteForm(string keyValue)
        {
            roleApp.DeleteForm(keyValue);
            return Success();
        }
    }
}
