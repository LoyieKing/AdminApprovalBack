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
        public IActionResult Index()
        {
            return Success(areaApp.GetList().ToTreeModel());
        }
        [HttpGet]
        public IActionResult Index(string keyword)
        {
            var data = areaApp.GetList();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.Where(it => it.F_FullName.Contains(keyword));
            }
            return Success(data.ToTreeModel());
        }
        [HttpGet]
        public IActionResult One(string keyValue)
        {
            var data = areaApp.FineOne(keyValue);
            return Success(data);
        }
        [HttpPost]
        public IActionResult Submit(AreaEntity areaEntity, string keyValue)
        {
            areaApp.Submit(areaEntity, keyValue);
            return Success();
        }
        [HttpPost]
        [HandlerAuthorize]
        public IActionResult Delete(string keyValue)
        {
            areaApp.Delete(keyValue);
            return Success();
        }
    }
}
