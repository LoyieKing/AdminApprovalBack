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
    public class OrganizeController : ControllerBase
    {
        private readonly OrganizeApp organizeApp;

        public OrganizeController(OrganizeApp organizeApp)
        {
            this.organizeApp = organizeApp;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = organizeApp.GetList();
            return Success(data.ToTreeModel());
        }
        [HttpGet]
        public IActionResult One(string keyValue)
        {
            var data = organizeApp.FineOne(keyValue);
            return Success(data);
        }
        [HttpPost]
        public IActionResult Submit(OrganizeEntity organizeEntity, string keyValue)
        {
            organizeApp.Submit(organizeEntity, keyValue);
            return Success();
        }
        [HttpPost]
        [HandlerAuthorize]
        public IActionResult Delete(string keyValue)
        {
            organizeApp.Delete(keyValue);
            return Success();
        }
    }
}
