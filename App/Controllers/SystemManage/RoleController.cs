using AdminApprovalBack.Models;
using Common;
using Data.Entity.SystemManage;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApprovalBack.Controllers.SystemManage
{
    public class RoleController:ControllerBase
    {
        private readonly RepoService<RoleEntity> repoService;
        private readonly RepoService<OrganizeCategoryEntity> catService;
        private readonly RepoService<MenuEntity> menuService;
        private readonly RepoService<RoleMenuEntity> roleMenuService;

        public RoleController(
            RepoService<RoleEntity> roleService,
            RepoService<OrganizeCategoryEntity> catService,
            RepoService<MenuEntity> menuService,
            RepoService<RoleMenuEntity> roleMenuService)
        {
            this.repoService = roleService;
            this.catService = catService;
            this.menuService = menuService;
            this.roleMenuService = roleMenuService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = repoService.IQueryable().Select(it => it.ToRoleModel());
            return Success(data);
        }

        [HttpPost]
        public IActionResult Update([FromBody] RoleModel roleModel)
        {
            var cat = roleModel.OrganizeCategoryId;
            if (cat == 0)
            {
                return Error("组织类型不能为空！");
            }
            if (catService.FindOne(cat) == null)
            {
                return Error("组织类型不存在！");
            }
            var menus = roleModel.AvailableMenuIds?.Select(it => menuService.FindOne(it));
            foreach
            if (menus.Any)
            {
                return Error("菜单类型错误！");
            }
            var roleEntity = new RoleEntity()
            {
                Id = roleModel.Id,
                Name = roleModel.Name!,
                Description = roleModel.Description ?? "",
                OrganizeCategoryId = roleModel.OrganizeCategoryId,
                OrganizeDutyLevel = roleModel.OrganizeDutyLevel!.Value,
            };
            repoService.Update(roleEntity);

            roleMenuService.Delete(it => it.Role.Id == roleModel.Id);
            roleModel.AvailableMenuIds?.ForEach(id => roleMenuService.Update(new RoleMenuEntity { Role = roleEntity, Menu = new MenuEntity { Id = id } }));

        }
    }
}
