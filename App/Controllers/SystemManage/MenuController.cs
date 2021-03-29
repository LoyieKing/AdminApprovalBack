using AdminApprovalBack.Models;
using Data.Entity.SystemManage;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApprovalBack.Controllers.SystemManage
{
    public class MenuController:ControllerBase
    {
        private readonly RepoService<MenuEntity> repoService;

        public MenuController(RepoService<MenuEntity> repoService)
        {
            this.repoService = repoService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var menus = repoService.IQueryable().Select(it => it.ToMenuModel());
            return Success(menus);
        }

        [HttpPost]
        public IActionResult Update(int? parent, MenuModel menu)
        {
            if (menu.Path != null && menu.Url != null)
            {
                return Error("路径和URL只能指定一个！");
            }
            MenuEntity menuEntity = menu.ToMenuEntity();
            if (parent != null)
            {
                var parentEntity = repoService.IQueryable().FirstOrDefault(it => it.Id == parent);
                if (parentEntity == null)
                {
                    return Error("父节点不存在！");
                }
                menuEntity.ParentId = parent;
            }
            repoService.Update(menuEntity);
            return Success();
        }

    }
}
