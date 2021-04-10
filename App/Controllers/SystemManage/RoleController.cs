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
    [Area("SystemManage")]
    public class RoleController : ControllerBase
    {
        private readonly RepoService<RoleEntity> repoService;
        private readonly RepoService<OrganizeCategoryEntity> catService;

        public RoleController(
            RepoService<RoleEntity> roleService,
            RepoService<OrganizeCategoryEntity> catService)
        {
            this.repoService = roleService;
            this.catService = catService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var entities = repoService.IQueryable().ToList();
            var data = entities.Select(it => new RoleModel().FromEntity(it)).ToList();
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

            var menus = roleModel.AvailableMenus?.ToList() ?? new List<string>();
            var approvals = roleModel.AvailableApprovals?.ToList() ?? new List<string>();
            if (menus.Any(string.IsNullOrWhiteSpace))
            {
                return Error("菜单类型错误！");
            }

            if (approvals.Any(string.IsNullOrWhiteSpace))
            {
                return Error("审批类型错误！");
            }

            var roleEntity = new RoleEntity
            {
                Id = roleModel.Id,
                Name = roleModel.Name!,
                Description = roleModel.Description ?? "",
                OrganizeCategoryId = roleModel.OrganizeCategoryId,
                OrganizeDutyLevel = roleModel.OrganizeDutyLevel!.Value,
                AvailableMenus = "," + string.Join(",", menus) + ",",
                AvailableApprovals = "," + string.Join(",", approvals) + ","
            };
            repoService.Update(roleEntity);

            return Success();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            repoService.Delete(id);
            return Success();
        }
    }
}