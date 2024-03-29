﻿using Common.Encrypt;
using Data.Entity.SystemManage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApprovalBack.Services.SystemManage;

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
        private readonly UserService userService2;

        public InitController(IWebHostEnvironment webHostEnvironment,
            RepoService<OrganizeCategoryEntity> organizeCatService,
            RepoService<OrganizeEntity> organizeService,
            RepoService<UserEntity> userService,
            RepoService<UserOrganizeEntity> userOrganizeService,
            UserService userService2)
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
            this.userService2 = userService2;
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


        [HttpGet]
        public IActionResult ChangePasswordSuper(string username, string pwd)
        {
            UserEntity? userEntity = userService.IQueryable().FirstOrDefault(t => t.UserName == username);
            if (userEntity == null)
            {
                throw new Exception("账户不存在，请重新输入");
            }

            userEntity.Password = userService2.HashPassword(pwd);
            userService.Update(userEntity);
            return Success();
        }
    }
}