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
        public IActionResult Index()
        {
            var data = moduleApp.GetList();
            return Success(data.ToTreeModel());
        }
        [HttpGet]
        public IActionResult One(string keyValue)
        {
            var data = moduleApp.FineOne(keyValue);
            return Success(data);
        }
        [HttpPost]
        public IActionResult Submit(ModuleEntity moduleEntity, string keyValue)
        {
            moduleApp.Submit(moduleEntity, keyValue);
            return Success();
        }
        [HttpPost]
        [HandlerAuthorize]
        public IActionResult Delete(string keyValue)
        {
            moduleApp.Delete(keyValue);
            return Success();
        }
    }
}
