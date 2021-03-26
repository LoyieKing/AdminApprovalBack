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
        public IActionResult Index(string itemId, string keyword)
        {
            var data = itemsDetailApp.GetList(itemId, keyword);
            return Success(data);
        }
        [HttpGet]
        public IActionResult Map(string enCode)
        {
            var data = itemsDetailApp
                .GetItemList(enCode)
                .Select(it => new { id = it.F_ItemCode, text = it.F_ItemName });
            return Success(data);
        }
        [HttpGet]
        public IActionResult One(string keyValue)
        {
            var data = itemsDetailApp.FineOne(keyValue);
            return Success(data);
        }
        [HttpPost]
        public IActionResult Submit(ItemsDetailEntity itemsDetailEntity, string keyValue)
        {
            itemsDetailApp.Submit(itemsDetailEntity, keyValue);
            return Success();
        }
        [HttpPost]
        [HandlerAuthorize]
        public IActionResult Delete(string keyValue)
        {
            itemsDetailApp.Delete(keyValue);
            return Success();
        }
    }
}
