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
        public IActionResult GetTreeJson()
        {
            var data = organizeApp.GetList();
            return Success(data.ToTreeModel());
        }
        [HttpGet]
        public IActionResult GetFormJson(string keyValue)
        {
            var data = organizeApp.GetForm(keyValue);
            return Success(data);
        }
        [HttpPost]
        public IActionResult SubmitForm(OrganizeEntity organizeEntity, string keyValue)
        {
            organizeApp.SubmitForm(organizeEntity, keyValue);
            return Success();
        }
        [HttpPost]
        [HandlerAuthorize]
        public IActionResult DeleteForm(string keyValue)
        {
            organizeApp.DeleteForm(keyValue);
            return Success();
        }
    }
}
