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

        public OrganizeController(RepoService<OrganizeEntity> repoService)
        {
            this.repoService = repoService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var datas = repoService.IQueryable().Select(it => new OrganizeModel().FromEntity(it));
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
            if (parent != 0)
            {
                if (repoService.FindOne(parent) == null)
                {
                    return Error("父组织不存在");
                }
            }
            if (repoService.FindOne(cat) == null)
            {
                return Error("组织类别不存在");
            }
            repoService.Update(new OrganizeEntity { Id = id, CategoryId = cat, Name = name, ParentId = parent });
            return Success();
        }
    }
}
