using Data.Infrastructure;
using Microsoft.AspNetCore.Http;
using Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AppService
    {
        protected readonly IHttpContextAccessor httpContextAccessor;

        public AppService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public void CreateEntity(ICreationAudited entity)
        {
            entity.F_Id = Common.Utils.GuId();
            var loginInfo = httpContextAccessor.HttpContext.GetUserInformation();
            entity.F_CreatorUserId = loginInfo?.Id;
            entity.F_CreatorTime = DateTime.Now;
        }

        public void ModifyEntity(IModificationAudited entity, string keyValue)
        {
            entity.F_Id = keyValue;
            var loginInfo = httpContextAccessor.HttpContext.GetUserInformation();
            entity.F_LastModifyUserId = loginInfo?.Id;
            entity.F_LastModifyTime = DateTime.Now;
        }

        public void RemoveEnityt(IDeleteAudited entity)
        {
            var loginInfo = httpContextAccessor.HttpContext.GetUserInformation();
            entity.F_DeleteUserId = loginInfo.Id;
            entity.F_DeleteTime = DateTime.Now;
            entity.F_DeleteMark = true;
        }
    }
}
