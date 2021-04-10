using AdminApprovalBack.Models;
using Common;
using Data.Entity.Approval;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApprovalBack.Controllers.Approval
{
    /// <summary>
    /// 单个信息
    /// 如身份证件信息、电话号码等
    /// </summary>
    public class InfoClassController : ControllerBase
    {
        private readonly RepoService<InfoClassEntity> repoService;

        public InfoClassController(RepoService<InfoClassEntity> repoService)
        {
            this.repoService = repoService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = repoService.IQueryable().Select(it => new InfoClassModel().FromEntity(it));
            return Success(data);
        }

        [HttpPost]
        public IActionResult Update([FromBody] List<InfoClassModel> infoItems)
        {
            using var trans = repoService.DbContext.Database.BeginTransaction();
            infoItems.Select(it =>
            {
                var name = it.Name;
                var cat = it.Category;
                var type = it.InputType;
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new Exception("名字不能为空");
                }

                if (string.IsNullOrWhiteSpace(cat))
                {
                    throw new Exception("分类不能为空");
                }

                if (string.IsNullOrWhiteSpace(type))
                {
                    throw new Exception("信息类型不能为空");
                }

                return it.ToEntity();
            }).ForEach(it => repoService.Update(it));
            trans.Commit();
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