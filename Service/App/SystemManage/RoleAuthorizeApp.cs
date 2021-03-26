using Common.Cache;
using Data.Entity.SystemManage;
using Data.IRepository.SystemManage;
using Data.Repository.SystemManage;
using Microsoft.AspNetCore.Http;
using Middleware;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdminApprovalBack.Services.SystemManage
{
    public class RoleAuthorizeApp : AppService<IRoleAuthorizeRepository,RoleAuthorizeEntity>
    {
        private readonly ModuleApp moduleApp;
        private readonly ModuleButtonApp moduleButtonApp;

        public RoleAuthorizeApp(IRoleAuthorizeRepository roleAuthorizeRepository,
            ModuleApp moduleApp,
            ModuleButtonApp moduleButtonApp,
            IHttpContextAccessor httpContextAccessor
            ) : base(roleAuthorizeRepository,httpContextAccessor)
        {
            this.moduleApp = moduleApp;
            this.moduleButtonApp = moduleButtonApp;
        }

        public IQueryable<RoleAuthorizeEntity> GetList(string roleId)
        {
            return GetList().Where(it => it.F_ObjectId == roleId);
        }
        public IQueryable<ModuleEntity> GetMenuList(string roleId)
        {
            var isadmin = httpContextAccessor.HttpContext.GetUserInformation()?.IsAdmin ?? false;
            IQueryable<ModuleEntity> data;
            if (isadmin)
            {
                data = moduleApp.GetList();
            }
            else
            {
                var moduledata = moduleApp.GetList();
                var authorizedata = GetList().Where(t => t.F_ObjectId == roleId && t.F_ItemType == 1);
                data = moduledata.Where(it => authorizedata.Any(a => a.F_ItemId == it.F_Id));
            }
            return data.OrderBy(t => t.F_SortCode);
        }
        public List<ModuleButtonEntity> GetButtonList(string roleId)
        {
            var isadmin = httpContextAccessor.HttpContext.GetUserInformation()?.IsAdmin ?? false;
            IQueryable<ModuleButtonEntity> data;
            if (isadmin)
            {
                data = moduleButtonApp.GetList();
            }
            else
            {
                var buttondata = moduleButtonApp.GetList();
                var authorizedata = GetList().Where(t => t.F_ObjectId == roleId && t.F_ItemType == 2);
                data = buttondata.Where(it => authorizedata.Any(a => a.F_ItemId == it.F_Id));
            }
            return data.OrderBy(t => t.F_SortCode).ToList();
        }
        public bool ActionValidate(string roleId, string moduleId, string action)
        {
            var authorizeurldata = new List<AuthorizeActionModel>();
            var cachedata = CacheFactory.Instance.GetCache<List<AuthorizeActionModel>>("authorizeurldata_" + roleId);
            if (cachedata == null)
            {
                var moduledata = GetMenuList(roleId);
                var buttondata = GetButtonList(roleId);
                authorizeurldata.AddRange(moduledata.Select(it => new AuthorizeActionModel { F_Id = it.F_Id, F_UrlAddress = it.F_UrlAddress }));
                authorizeurldata.AddRange(buttondata.Select(it => new AuthorizeActionModel { F_Id = it.F_ModuleId, F_UrlAddress = it.F_UrlAddress }));
                CacheFactory.Instance.WriteCache(authorizeurldata, "authorizeurldata_" + roleId, DateTime.Now.AddMinutes(5));
            }
            else
            {
                authorizeurldata = cachedata;
            }
            //authorizeurldata = authorizeurldata.FindAll(t => t.F_Id.Equals(moduleId));
            foreach (var item in authorizeurldata)
            {
                if (!string.IsNullOrEmpty(item.F_UrlAddress))
                {
                    string[] url = item.F_UrlAddress.Split('?');
                    if (item.F_Id == moduleId && url[0] == action)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public class AuthorizeActionModel
        {
            public string F_Id { set; get; }
            public string F_UrlAddress { set; get; }
        }
    }
}
