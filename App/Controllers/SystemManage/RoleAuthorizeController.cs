using AdminApprovalBack.Models;
using AdminApprovalBack.Services.SystemManage;
using Data.Entity.SystemManage;
using Data.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace AdminApprovalBack.Controllers.SystemManage
{
    [Area("SystemManage")]
    public class RoleAuthorizeController : ControllerBase
    {
        private readonly RoleAuthorizeApp roleAuthorizeApp;
        private readonly ModuleApp moduleApp;
        private readonly ModuleButtonApp moduleButtonApp;

        public RoleAuthorizeController(RoleAuthorizeApp roleAuthorizeApp, ModuleApp moduleApp, ModuleButtonApp moduleButtonApp)
        {
            this.roleAuthorizeApp = roleAuthorizeApp;
            this.moduleApp = moduleApp;
            this.moduleButtonApp = moduleButtonApp;
        }

        public IActionResult GetPermissionTree(string roleId)
        {
            var moduledata = moduleApp.GetList();
            var buttondata = moduleButtonApp.GetList();
            var authorizedata = new List<RoleAuthorizeEntity>();
            if (!string.IsNullOrEmpty(roleId))
            {
                authorizedata = roleAuthorizeApp.GetList(roleId).ToList();
            }
            var treeList = moduledata.Select(it => new RoleTreeModel<ModuleEntity, ModuleButtonEntity>(it, authorizedata.Count(a => a.F_ItemId == it.F_Id)));
            var buttonList = buttondata.Select(it => new RoleTreeModel<ModuleButtonEntity, ModuleButtonEntity>(it, authorizedata.Count(a => a.F_ItemId == it.F_Id)));
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


        public class RoleTreeModel<TData, TChildren>
            where TData : IEntity<TData>, ITreeEntity
            where TChildren : IEntity<TChildren>, ITreeEntity
        {
            [JsonProperty("data")]
            public TData Data { get; set; }

            [JsonProperty("state")]
            public int State { get; set; }

            [JsonProperty("children")]
            public List<RoleTreeModel<TChildren, TChildren>> Children { get; set; } = new List<RoleTreeModel<TChildren, TChildren>>();

            public RoleTreeModel(TData data,int state)
            {
                Data = data;
                State = state;
            }
        }
    }



}
