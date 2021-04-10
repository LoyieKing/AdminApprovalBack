using AdminApprovalBack.Models;
using AdminApprovalBack.Services.SystemManage;
using Data.Entity.Approval;
using Data.Entity.Business;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdminApprovalBack.Controllers.Business
{
    public class ApprovalInstanceController : ControllerBase
    {
        private readonly RepoService<ApprovalInstanceEntity> repoService;
        private readonly RepoService<ApprovalTableEntity> tableRepoService;
        private readonly RepoService<InfoClassEntity> infoClassService;
        private readonly RepoService<InfoInstanceEntity> infoInstanceService;
        private readonly UserService userService;

        public ApprovalInstanceController(RepoService<ApprovalInstanceEntity> repoService,
            RepoService<ApprovalTableEntity> tableRepoService,
            RepoService<InfoClassEntity> infoClassService,
            RepoService<InfoInstanceEntity> infoInstanceService,
            UserService userService)
        {
            this.repoService = repoService;
            this.tableRepoService = tableRepoService;
            this.infoClassService = infoClassService;
            this.infoInstanceService = infoInstanceService;
            this.userService = userService;
        }

        private List<ApprovalInstanceEntity> findAll(Expression<Func<ApprovalInstanceEntity, bool>>? predict = null)
        {
            var user = GetUserInformation();
            var data = repoService.IQueryable().Where(it => it.User.Id == user.Id || it.CreatorUserId == user.Id);
            if (predict != null)
            {
                data = data.Where(predict);
            }

            return data.ToList();
        }

        private object entityToModel(ApprovalInstanceEntity it)
        {
            var ids = it.InfoInstances.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var infoInstances = infoInstanceService.IQueryable().Where(it => ids.Contains(it.Id)).ToList();
            return new
            {
                id = it.Id,
                desc = it.Description,
                prototype = it.AppprovalTable.Name,
                values = infoInstances.Select(info =>
                {
                    var infoClass = infoClassService.FindOne(info.Id)!;
                    return new
                    {
                        id = info.Id,
                        prototypeId = infoClass.Id,
                        name = infoClass.Name,
                        type = infoClass.InputType,
                        value = info.Value,
                        status = info.Status
                    };
                }),
                creator = it.CreatorUser?.RealName,
                modifer = it.LastModifyUser?.RealName,
                state = it.State
            };
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = findAll().Select(entityToModel);
            return Success(data);
        }

        [HttpGet]
        public IActionResult Waiting()
        {
            var data = findAll(it => it.State == "waiting").Select(entityToModel);
            return Success(data);
        }

        [HttpPost]
        public IActionResult UpdateStatus(int id, string status, [FromBody] InfoInstanceStatus[]? infoInstanceStatus)
        {
            using var trans = repoService.DbContext.Database.BeginTransaction();
            var entity = repoService.FindOne(id);
            if (entity == null) throw new Exception("审核表不存在！");
            entity.State = status;
            repoService.Update(entity);
            Dictionary<int, string> infoStatusMap =
                infoInstanceStatus?.ToDictionary(it => it.Id, it => it.Status) ??
                new Dictionary<int, string>();
            var instances = infoInstanceService.IQueryable().Where(it => infoStatusMap.Keys.Contains(it.Id)).ToList();
            if (instances.Count != infoStatusMap.Count) throw new Exception("不存在的信息项！");
            foreach (var infoInstanceEntity in instances)
            {
                infoInstanceEntity.Status = infoStatusMap[infoInstanceEntity.Id];
                infoInstanceService.Update(infoInstanceEntity);
            }

            trans.Commit();
            return Success();
        }

        [HttpPost]
        public IActionResult New([FromBody] NewApprovalParam param)
        {
            using var trans = userService.DbContext.Database.BeginTransaction();
            var userInfo = GetUserInformation();
            var user = userService.FindOne(userInfo.Id);
            if (user == null) throw new Exception("权限不足！");
            var table = tableRepoService.FindOne(param.PrototypeId);
            if (table == null) throw new Exception("无效的审核类型！");
            ApprovalInstanceEntity approvalInstanceEntity = new ApprovalInstanceEntity();
            approvalInstanceEntity.AppprovalTable = table;
            approvalInstanceEntity.Description = param.Description;
            approvalInstanceEntity.InfoInstances = "";
            approvalInstanceEntity.State = "waiting";
            approvalInstanceEntity.User = user;
            foreach (var entry in param.Values)
            {
                var infoClass = infoClassService.FindOne(entry.Key);
                if (infoClass == null)
                {
                    throw new Exception("无效的审核信息！");
                }


                var infoEntity = new InfoInstanceEntity
                    {User = user, PrototypeId = entry.Key, Value = entry.Value, Status = "waiting"};
                infoInstanceService.Update(infoEntity);

                approvalInstanceEntity.InfoInstances += "," + infoEntity.Id;
            }

            repoService.Update(approvalInstanceEntity);
            trans.Commit();
            return Success();
        }

        public class NewApprovalParam
        {
            public int PrototypeId { get; set; }
            public Dictionary<int, string> Values { get; set; }
            public string Description { get; set; }
        }

        public class InfoInstanceStatus
        {
            public int Id { get; set; }
            public string Status { get; set; }
        }
    }
}