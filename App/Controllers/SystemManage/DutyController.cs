using AdminApprovalBack.Interceptors;
using AdminApprovalBack.Services.SystemManage;
using Data.Entity.SystemManage;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AdminApprovalBack.Controllers.SystemManage
{
    [Area("SystemManage")]
    public class DutyController : ControllerBase
    {
        private readonly DutyApp dutyApp;

        public DutyController(DutyApp dutyApp)
        {
            this.dutyApp = dutyApp;
        }

        [HttpGet]
        public IActionResult GetGridJson(string keyword)
        {
            var data = dutyApp.GetList(keyword);
            return Success(data);
        }
        [HttpGet]
        public IActionResult GetFormJson(string keyValue)
        {
            var data = dutyApp.GetForm(keyValue);
            return Success(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitForm(RoleEntity roleEntity, string keyValue)
        {
            dutyApp.SubmitForm(roleEntity, keyValue);
            return Success();
        }
        [HttpPost]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteForm(string keyValue)
        {
            dutyApp.DeleteForm(keyValue);
            return Success();
        }
    }
}
