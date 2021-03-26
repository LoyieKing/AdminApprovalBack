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
        public IActionResult Index(string keyword)
        {
            var data = roleApp.GetList(keyword);
            return Success(data);
        }
        [HttpGet]
        public IActionResult One(string keyValue)
        {
            var data = roleApp.FineOne(keyValue);
            return Success(data);
        }
        [HttpPost]
        public IActionResult Submit(RoleEntity roleEntity, string[] permissionIds, string keyValue)
        {
            roleApp.Submit(roleEntity, permissionIds, keyValue);
            return Success();
        }
        [HttpPost]
        [HandlerAuthorize]
        public IActionResult Delete(string keyValue)
        {
            roleApp.Delete(keyValue);
            return Success();
        }
    }
}
