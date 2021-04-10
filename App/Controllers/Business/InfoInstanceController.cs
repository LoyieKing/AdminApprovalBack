using AdminApprovalBack.Models;
using AdminApprovalBack.Services.SystemManage;
using Data.Entity.Business;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entity.Approval;

namespace AdminApprovalBack.Controllers.Business
{
    public class InfoInstanceController : ControllerBase
    {
        private readonly RepoService<InfoInstanceEntity> repoService;
        private readonly RepoService<InfoClassEntity> infoClassService;
        private readonly UserService userService;

        public InfoInstanceController(
            RepoService<InfoInstanceEntity> repoService,
            RepoService<InfoClassEntity> infoClassService,
            UserService userService)
        {
            this.repoService = repoService;
            this.infoClassService = infoClassService;
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = GetUserInformation();
            var data = repoService
                .IQueryable()
                .Where(it => it.User.Id == user.Id)
                .ToList().Select(it =>
                {
                    var model = new InfoInstanceModel().FromEntity(it);
                    model.InfoClass = new InfoClassModel().FromEntity(infoClassService.FindOne(it.PrototypeId)!);
                    return model;
                });
            return Success(data);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var user = GetUserInformation();
            var ins = repoService.FindOne(id);
            if (ins == null) throw new Exception("信息不存在！");
            if (ins.User.Id != user.Id && !user.IsAdmin) throw new Exception("权限不足！");
            repoService.Delete(ins);
            return Success();
        }

        [HttpPost]
        public IActionResult SetStatus(int id, string state)
        {
            var user = GetUserInformation();
            var ins = repoService.FindOne(id);
            if (ins == null) throw new Exception("信息不存在！");

            var authorized = user.IsAdmin || userService.IsHigherLevel(ins.User.Id, user.Id);
            if (state == "expired")
            {
                authorized |= ins.User.Id == user.Id;
            }

            if (!authorized) throw new Exception("权限不足！");
            ins.Status = state;
            repoService.Update(ins);
            return Success();
        }
    }
}