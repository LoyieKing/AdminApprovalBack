using AdminApprovalBack.Models;
using AdminApprovalBack.Services.SystemManage;
using Data.Entity.SystemManage;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AdminApprovalBack.Controllers.SystemManage
{
    [Area("SystemManage")]
    public class ModuleButtonController : ControllerBase
    {
        private readonly ModuleApp moduleApp;
        private readonly ModuleButtonApp moduleButtonApp;

        public ModuleButtonController(ModuleApp moduleApp, ModuleButtonApp moduleButtonApp)
        {
            this.moduleApp = moduleApp;
            this.moduleButtonApp = moduleButtonApp;
        }

        [HttpGet]
        public IActionResult Index(string moduleId)
        {
            var data = moduleButtonApp.GetList(moduleId);
            return Success(data.ToTreeModel());
        }
        [HttpGet]
        public IActionResult One(string keyValue)
        {
            var data = moduleButtonApp.FineOne(keyValue);
            return Success(data);
        }
        [HttpPost]
        public IActionResult Submit(ModuleButtonEntity moduleButtonEntity, string keyValue)
        {
            moduleButtonApp.Submit(moduleButtonEntity, keyValue);
            return Success();
        }
        [HttpPost]
        public IActionResult Delete(string keyValue)
        {
            moduleButtonApp.Delete(keyValue);
            return Success();
        }
        [HttpGet]
        public IActionResult All()
        {
            var moduledata = moduleApp.GetList().ToList();
            var buttondata = moduleButtonApp.GetList().ToList();
            var treeList = moduledata.Select(it => new TreeModel<ModuleEntity, ModuleButtonEntity>(it));
            var buttonList = buttondata.Select(it => new TreeModel<ModuleButtonEntity>(it));
            var moduleMap = treeList.ToDictionary(it => it.Data.F_Id);
            var buttonMap = buttonList.ToDictionary(it => it.Data.F_Id);

            foreach (var btn in buttonList)
            {
                if (btn.Data.F_ParentId == "0")
                {
                    moduleMap[btn.Data.F_ModuleId]?.Children.Add(btn);
                }
                else
                {
                    buttonMap[btn.Data.F_ParentId]?.Children.Add(btn);
                }
            }
            return Success(treeList);
        }
        [HttpPost]
        public IActionResult CloneButton(string moduleId, string[] ids)
        {
            moduleButtonApp.SubmitCloneButton(moduleId, ids);
            return Success();
        }
    }
}
