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
    [Area("SystemManage")]
    public class OrganizeController : ControllerBase
    {
        private readonly RepoService<OrganizeEntity> repoService;
        private readonly RepoService<OrganizeCategoryEntity> catService;

        public OrganizeController(RepoService<OrganizeEntity> repoService,
            RepoService<OrganizeCategoryEntity> catService)
        {
            this.repoService = repoService;
            this.catService = catService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var datas = repoService.IQueryable().Select(it => new OrganizeModel().FromEntity(it)).ToList();
            return Success(datas);
        }

        [HttpPost]
        public IActionResult Update(int id, string name, int cat, int parent)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Error("组织名不能为空！");
            }

            if (cat == 0)
            {
                return Error("组织分类不能为空！");
            }

            OrganizeEntity? parentEntity = null;
            if (parent != 0)
            {
                parentEntity = repoService.FindOne(parent);
                if (parentEntity == null)
                {
                    return Error("父组织不存在");
                }
            }

            if (catService.FindOne(cat) == null)
            {
                return Error("组织类别不存在");
            }

            repoService.Update(new OrganizeEntity
                {Id = id, CategoryId = cat, Name = name, ParentId = parent, Parent = parentEntity});
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