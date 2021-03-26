﻿using AdminApprovalBack.Interceptors;
using AdminApprovalBack.Services.SystemManage;
using Data.Entity.SystemManage;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AdminApprovalBack.Controllers.SystemManage
{
    [Area("SystemManage")]
    public class DutyController : ControllerBase
    {
        private readonly DutyApp dutyApp;

        public DutyController(DutyApp dutyApp)
        {
            this.dutyApp = dutyApp;
        }

        [HttpGet]
        public IActionResult Index(string keyword = "")
        {
            var data = dutyApp.GetList(keyword);
            return Success(data);
        }
        [HttpGet]
        public IActionResult One(string keyValue)
        {
            var data = dutyApp.FineOne(keyValue);
            return Success(data);
        }
        [HttpPost]
        public IActionResult Submit(RoleEntity roleEntity, string keyValue)
        {
            dutyApp.Submit(roleEntity, keyValue);
            return Success();
        }
        [HttpPost]
        [HandlerAuthorize]
        public IActionResult Delete(string keyValue)
        {
            dutyApp.Delete(keyValue);
            return Success();
        }
    }
}
