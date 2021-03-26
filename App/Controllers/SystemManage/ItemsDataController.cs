using AdminApprovalBack.Interceptors;
using AdminApprovalBack.Services.SystemManage;
using Data.Entity.SystemManage;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AdminApprovalBack.Controllers.SystemManage
{
    [Area("SystemManage")]
    public class ItemsDataController : ControllerBase
    {
        private readonly ItemsDetailApp itemsDetailApp;

        public ItemsDataController(ItemsDetailApp itemsDetailApp)
        {
            this.itemsDetailApp = itemsDetailApp;
        }

        [HttpGet]
        public IActionResult GetGridJson(string itemId, string keyword)
        {
            var data = itemsDetailApp.GetList(itemId, keyword);
            return Success(data);
        }
        [HttpGet]
        public IActionResult GetSelectJson(string enCode)
        {
            var data = itemsDetailApp
                .GetItemList(enCode)
                .Select(it => new { id = it.F_ItemCode, text = it.F_ItemName });
            return Success(data);
        }
        [HttpGet]
        public IActionResult GetFormJson(string keyValue)
        {
            var data = itemsDetailApp.GetForm(keyValue);
            return Success(data);
        }
        [HttpPost]
        public IActionResult SubmitForm(ItemsDetailEntity itemsDetailEntity, string keyValue)
        {
            itemsDetailApp.SubmitForm(itemsDetailEntity, keyValue);
            return Success();
        }
        [HttpPost]
        [HandlerAuthorize]
        public IActionResult DeleteForm(string keyValue)
        {
            itemsDetailApp.DeleteForm(keyValue);
            return Success();
        }
    }
}
