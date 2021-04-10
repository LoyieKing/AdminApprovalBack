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
        private readonly RepoService<InfoClassEntity> infoClassService;
        private readonly RepoService<ApprovalTableOrganizeEntity> tableOrganizeService;
        private readonly RepoService<ApprovalTableInfoClassEntity> tableInfoClassService;

        public ApprovalTableController(RepoService<ApprovalTableEntity> repoService,
            RepoService<OrganizeEntity> organizeService,
            RepoService<InfoClassEntity> infoClassService,
            RepoService<ApprovalTableOrganizeEntity> tableOrganizeService,
            RepoService<ApprovalTableInfoClassEntity> tableInfoClassService)
        {
            this.repoService = repoService;
            this.organizeService = organizeService;
            this.infoClassService = infoClassService;
            this.tableOrganizeService = tableOrganizeService;
            this.tableInfoClassService = tableInfoClassService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = repoService.IQueryable().ToList().Select(it => new ApprovalTableModel().FromEntity(it));
            return Success(data);
        }

        [HttpGet]
        public IActionResult FindOne(int id)
        {
            var data = new ApprovalTableModel().FromEntity(repoService.FindOne(id));
            return Success(data);
        }

        [HttpPost]
        public IActionResult Update([FromBody] ApprovalTableModel approvalTable)
        {
            using var trans = repoService.DbContext.Database.BeginTransaction();

            var orgIds = approvalTable.OwnerOrganizes ?? new List<int>();
            var orgs = organizeService.IQueryable().Where(it => orgIds.Contains(it.Id)).ToList();
            if (orgs.Count != orgIds.Count) throw new Exception("组织不存在！");
            var infoClassIds = approvalTable.InfoClasses ?? new List<int>();
            var infoClasses = infoClassService.IQueryable().Where(it => infoClassIds.Contains(it.Id)).ToList();
            if (infoClassIds.Count != infoClasses.Count) throw new Exception("类型不存在！");
            var entity = approvalTable.ToEntity();
            repoService.Update(entity);
            tableInfoClassService.Delete(it => it.ApprovalTable.Id == entity.Id);
            tableOrganizeService.Delete(it => it.ApprovalTable.Id == entity.Id);
            foreach (var infoClassEntity in infoClasses)
            {
                tableInfoClassService.Update(new ApprovalTableInfoClassEntity
                {
                    ApprovalTable = entity,
                    InfoClass = infoClassEntity
                });
            }

            foreach (var organizeEntity in orgs)
            {
                tableOrganizeService.Update(new ApprovalTableOrganizeEntity
                {
                    ApprovalTable = entity,
                    Organize = organizeEntity
                });
            }

            trans.Commit();
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