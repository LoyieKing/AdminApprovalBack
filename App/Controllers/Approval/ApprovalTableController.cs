using AdminApprovalBack.Models;
using Data.Entity.Approval;
using Data.Entity.SystemManage;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApprovalBack.Controllers.Approval
{
    public class ApprovalTableController : ControllerBase
    {
        private readonly RepoService<ApprovalTableEntity> repoService;
        private readonly RepoService<OrganizeEntity> organizeService;

        public ApprovalTableController(RepoService<ApprovalTableEntity> repoService,RepoService<OrganizeEntity> organizeService)
        {
            this.repoService = repoService;
            this.organizeService = organizeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = repoService.IQueryable().Select(it => new ApprovalTableModel().FromEntity(it));
            return Success(data);
        }

        [HttpGet]
        public IActionResult FindOne(int id)
        {
            var data = new ApprovalTableModel().FromEntity(repoService.FindOne(id));
            return Success(data);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ApprovalTableModel approvalTable, [FromQuery] int orgId)
        {
            approvalTable.Id = 0;
            var org = organizeService.FindOne(orgId);
            if (org == null) throw new Exception("组织不存在！");
            var entity = approvalTable.ToEntity();
            entity.OwnerOrganize = org;
            repoService.Update(entity);
            return Success();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            organizeService.Delete(id);
            return Success();
        }

    }
}
