using Common.Encrypt;
using Data.Entity.SystemManage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApprovalBack.Controllers.SystemSecurity
{
    [Area("SystemSecurity")]
    public class InitController : ControllerBase
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly RepoService<OrganizeCategoryEntity> organizeCatService;
        private readonly RepoService<OrganizeEntity> organizeService;
        private readonly RepoService<UserEntity> userService;
        private readonly RepoService<UserOrganizeEntity> userOrganizeService;

        public InitController(IWebHostEnvironment webHostEnvironment,
            RepoService<OrganizeCategoryEntity> organizeCatService,
            RepoService<OrganizeEntity> organizeService,
            RepoService<UserEntity> userService,
            RepoService<UserOrganizeEntity> userOrganizeService)
        {
            if (!webHostEnvironment.IsDevelopment())
            {
                HttpContext.Response.StatusCode = 404;
                throw new Exception("Unknown page");
            }

            this.webHostEnvironment = webHostEnvironment;
            this.organizeCatService = organizeCatService;
            this.organizeService = organizeService;
            this.userService = userService;
            this.userOrganizeService = userOrganizeService;
        }

        [HttpGet]
        public IActionResult Init()
        {
            using var trans = organizeService.DbContext.Database.BeginTransaction();

            var organizeCat = new OrganizeCategoryEntity
            {
                Name = "管理办公室",
                Category = OrganizeCategoryEntity.Categories.Main,
            };
            organizeCatService.Update(organizeCat);

            var organize = new OrganizeEntity
            {
                Name = "研发运维",
                CategoryId = organizeCat.Id,
                Category = organizeCat,
            };
            organizeService.Update(organize);

            var user = new UserEntity
            {
                UserName = "admin",
                RealName = "运维超级账号",
                Contract = "{\"wechat\":\"loyieking\"}",
                IsAdministrator = true,
                Password = Md5.Hash(DesEncrypt.Encrypt("adminadmin").ToLower(), 32).ToLower()
            };
            userService.Update(user);

            var userOrganize = new UserOrganizeEntity
            {
                User = user,
                Organize = organize
            };
            userOrganizeService.Update(userOrganize);

            trans.Commit();

            return Success();
        }
    }
}
