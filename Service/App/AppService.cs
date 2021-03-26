using Data.Entity.SystemManage;
using Data.Infrastructure;
using Data.IRepository.SystemManage;
using Data.RepositoryBase;
using Microsoft.AspNetCore.Http;
using Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public abstract class AppService<TRepo, TEnitity>
        where TRepo : IRepositoryBase<TEnitity>
        where TEnitity : IEntity<TEnitity>,new ()
    {
        protected readonly IHttpContextAccessor httpContextAccessor;
        protected readonly TRepo repo;

        public AppService(TRepo repo, IHttpContextAccessor httpContextAccessor)
        {
            this.repo = repo;
            this.httpContextAccessor = httpContextAccessor;
        }
        public virtual IQueryable<TEnitity> GetList()
        {
            return repo.IQueryable();
        }
        public virtual TEnitity GetForm(string keyValue)
        {
            return repo.FindEntity(keyValue);
        }
        public virtual void DeleteForm(string keyValue)
        {
            repo.Delete(t => t.F_Id == keyValue);
        }
        public virtual void SubmitForm(TEnitity entity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                ModifyEntity(entity, keyValue);
                repo.Update(entity);
            }
            else
            {
                CreateEntity(entity);
                repo.Insert(entity);
            }
        }


        protected virtual void CreateEntity(TEnitity entity)
        {
            entity.F_Id = Common.Utils.GuId();
            var loginInfo = httpContextAccessor.HttpContext.GetUserInformation();
            entity.F_CreatorUserId = loginInfo?.Id;
            entity.F_CreatorTime = DateTime.Now;
        }

        protected virtual void ModifyEntity(TEnitity entity, string keyValue)
        {
            entity.F_Id = keyValue;
            var loginInfo = httpContextAccessor.HttpContext.GetUserInformation();
            entity.F_LastModifyUserId = loginInfo?.Id;
            entity.F_LastModifyTime = DateTime.Now;
        }

        protected virtual void RemoveEntity(TEnitity entity)
        {
            var loginInfo = httpContextAccessor.HttpContext.GetUserInformation();
            entity.F_DeleteUserId = loginInfo.Id;
            entity.F_DeleteTime = DateTime.Now;
            entity.F_DeleteMark = true;
        }
    }
}
