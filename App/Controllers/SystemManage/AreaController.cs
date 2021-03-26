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
    public class AreaController : ControllerBase
    {
        private readonly AreaApp areaApp;

        public AreaController(AreaApp areaApp)
        {
            this.areaApp = areaApp;
        }

        [HttpGet]
        public IActionResult GetTreeSelectJson()
        {
            return Success(areaApp.GetList().Select(it => new { id = it.F_Id, text = it.F_FullName, parentId = it.F_ParentId }));
        }
        [HttpGet]
        public IActionResult GetTreeGridJson(string keyword)
        {
            var data = areaApp.GetList();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.Where(it => it.F_FullName.Contains(keyword));
            }
            return Success(data.ToTreeModel());
        }
        [HttpGet]
        public IActionResult GetFormJson(string keyValue)
        {
            var data = areaApp.GetForm(keyValue);
            return Success(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitForm(AreaEntity areaEntity, string keyValue)
        {
            areaApp.SubmitForm(areaEntity, keyValue);
            return Success();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandlerAuthorize]
        public IActionResult DeleteForm(string keyValue)
        {
            areaApp.DeleteForm(keyValue);
            return Success();
        }
    }
}
