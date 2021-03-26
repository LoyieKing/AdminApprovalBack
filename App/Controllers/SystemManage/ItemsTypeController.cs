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
        public IActionResult Index()
        {
            var data = itemsApp.GetList();
            return Json(data.ToTreeModel());
        }
        [HttpGet]
        public IActionResult One(string keyValue)
        {
            var data = itemsApp.FineOne(keyValue);
            return Success(data);
        }
        [HttpPost]
        public IActionResult Submit(ItemsEntity itemsEntity, string keyValue)
        {
            itemsApp.Submit(itemsEntity, keyValue);
            return Success();
        }
        [HttpPost]
        public IActionResult Delete(string keyValue)
        {
            itemsApp.Delete(keyValue);
            return Success();
        }
    }
}
