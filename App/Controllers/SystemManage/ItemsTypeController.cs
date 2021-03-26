using AdminApprovalBack.Models;
using AdminApprovalBack.Services.SystemManage;
using Data.Entity.SystemManage;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AdminApprovalBack.Controllers.SystemManage
{
    [Area("SystemManage")]
    public class ItemsTypeController : ControllerBase
    {
        private readonly ItemsApp itemsApp;

        public ItemsTypeController(ItemsApp itemsApp)
        {
            this.itemsApp = itemsApp;
        }

        [HttpGet]
        public IActionResult GetTreeJson()
        {
            var data = itemsApp.GetList();
            return Json(data.ToTreeModel());
        }
        [HttpGet]
        public IActionResult GetFormJson(string keyValue)
        {
            var data = itemsApp.GetForm(keyValue);
            return Success(data);
        }
        [HttpPost]
        public IActionResult SubmitForm(ItemsEntity itemsEntity, string keyValue)
        {
            itemsApp.SubmitForm(itemsEntity, keyValue);
            return Success();
        }
        [HttpPost]
        public IActionResult DeleteForm(string keyValue)
        {
            itemsApp.DeleteForm(keyValue);
            return Success();
        }
    }
}
