using AdminApprovalBack.Interceptors;
using AdminApprovalBack.Models;
using AdminApprovalBack.Services.SystemManage;
using Data.Entity.SystemManage;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AdminApprovalBack.Controllers.SystemManage
{
    [Area("SystemManage")]
    public class ModuleController : ControllerBase
    {
        private readonly ModuleApp moduleApp;

        public ModuleController(ModuleApp moduleApp)
        {
            this.moduleApp = moduleApp;
        }

        [HttpGet]
        public IActionResult GetTreeJson()
        {
            var data = moduleApp.GetList();
            return Success(data.ToTreeModel());
        }
        [HttpGet]
        public IActionResult GetFormJson(string keyValue)
        {
            var data = moduleApp.GetForm(keyValue);
            return Success(data);
        }
        [HttpPost]
        public IActionResult SubmitForm(ModuleEntity moduleEntity, string keyValue)
        {
            moduleApp.SubmitForm(moduleEntity, keyValue);
            return Success();
        }
        [HttpPost]
        [HandlerAuthorize]
        public IActionResult DeleteForm(string keyValue)
        {
            moduleApp.DeleteForm(keyValue);
            return Success();
        }
    }
}
