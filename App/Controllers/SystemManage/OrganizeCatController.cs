using AdminApprovalBack.Models;
using Data.Entity.SystemManage;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AdminApprovalBack.Controllers.SystemManage
{
    [Area("SystemManage")]
    public class OrganizeCatController : ControllerBase
    {
        private readonly RepoService<OrganizeCategoryEntity> repoService;

        public OrganizeCatController(RepoService<OrganizeCategoryEntity> repoService)
        {
            this.repoService = repoService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var datas = repoService.IQueryable().Select(it => new OrganizeCategoryModel().FromEntity(it)).ToList();
            return Success(datas);
        }

        [HttpGet]
        public IActionResult One(int id)
        {
            var datas = repoService.FindOne(id);
            return Success(datas);
        }

        [HttpPost]
        public IActionResult Update(int id, string name, int cat)
        {
            name = HttpUtility.UrlDecode(name);
            if (string.IsNullOrEmpty(name))
            {
                return Error("组织类型名不能为空！");
            }

            if (cat < 0 || cat > 1)
            {
                return Error("组织类别不存在");
            }

            repoService.Update(new OrganizeCategoryEntity
                {Id = id, Category = (OrganizeCategoryEntity.Categories) cat, Name = name});
            return Success();
        }

        [HttpPost]
        public IActionResult Delete([FromBody] int[] ids)
        {
            using var trans = repoService.DbContext.Database.BeginTransaction();
            foreach (var id in ids)
            {
                repoService.Delete(id);
            }

            trans.Commit();
            return Success();
        }
    }
}