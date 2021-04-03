using AdminApprovalBack.Models;
using AdminApprovalBack.Services.SystemManage;
using Data.Entity.Approval;
using Data.Entity.Business;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApprovalBack.Controllers.Business
{
    public class ApprovalInstanceController : ControllerBase
    {
        private readonly RepoService<ApprovalInstanceEntity> repoService;
        private readonly RepoService<ApprovalTableEntity> tableRepoService;
        private readonly RepoService<InfoClassEntity> infoClassService;
        private readonly UserService userService;

        public ApprovalInstanceController(RepoService<ApprovalInstanceEntity> repoService,
            RepoService<ApprovalTableEntity> tableRepoService,
            RepoService<InfoClassEntity> infoClassService,
            UserService userService)
        {
            this.repoService = repoService;
            this.tableRepoService = tableRepoService;
            this.infoClassService = infoClassService;
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = GetUserInformation();
            var data = repoService.IQueryable().Where(it => it.User.Id == user.Id).Select(it => new
            {
                id = it.Id,
                desc = it.Description,
                prototype = it.AppprovalTable.Id,
                values = it.InfoInstances.Select(info => new { prototype = new InfoClassModel().FromEntity(info.InfoClass), value = info.Value, status = info.Status })
            });
            return Success(data);
        }

        [HttpPost]
        public IActionResult New(NewApprovalParam param)
        {
            var userInfo = GetUserInformation();
            var user = userService.FindOne(userInfo.Id);
            if (user == null) throw new Exception("权限不足！");
            var table = tableRepoService.FindOne(param.PrototypeId);
            if (table == null) throw new Exception("无效的审核类型！");
            ApprovalInstanceEntity approvalInstanceEntity = new ApprovalInstanceEntity();
            approvalInstanceEntity.AppprovalTable = table;
            approvalInstanceEntity.Description = param.Description;
            foreach (var entry in param.Values)
            {
                var infoClass = infoClassService.FindOne(entry.Key);
                if (infoClass == null)
                {
                    throw new Exception("无效的审核信息！");
                }
                approvalInstanceEntity.InfoInstances.Add(new InfoInstanceEntity { User = user, InfoClass = infoClass, Value = entry.Value });
            }
            repoService.Update(approvalInstanceEntity);
            return Success();
        }

        public class NewApprovalParam
        {
            public int PrototypeId { get; set; }
            public Dictionary<int,string> Values { get; set; }
            public string Description { get; set; }
        }
    }
}
