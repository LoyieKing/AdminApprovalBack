using Data.Entity.SystemManage;
using Data.Infrastructure;
using Data.RepositoryBase;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Service.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RepoService<TEnitity>
        where TEnitity : IEntity,new ()
    {
        protected readonly IHttpContextAccessor httpContextAccessor;
        protected readonly IRepository<TEnitity> repo;

        public DbContext DbContext { get => repo.DbContext; }

        public RepoService(IRepository<TEnitity> repo, IHttpContextAccessor httpContextAccessor)
        {
            this.repo = repo;
            this.httpContextAccessor = httpContextAccessor;
        }
        public virtual IQueryable<TEnitity> IQueryable()
        {
            return repo.IQueryable();
        }
        public virtual TEnitity FindOne(int id)
        {
            return repo.FindEntity(id);
        }

        public virtual void Delete(int id)
        {
            repo.Delete(t => t.Id == id);
        }

        public virtual void Delete(Expression<Func<TEnitity, bool>> cond)
        {
            repo.Delete(cond);
        }

        public virtual void Delete(TEnitity enitity)
        {
            repo.Delete(enitity);
        }

        public virtual void Update(TEnitity entity)
        {
            if (entity.Id != 0)
            {
                ModifyEntity(entity);
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
            var loginInfo = httpContextAccessor.HttpContext.GetUserInformation();
            entity.CreatorUserId = loginInfo?.Id ?? 0;
            entity.CreatorTime = DateTime.Now;
        }

        protected virtual void ModifyEntity(TEnitity entity)
        {
            var loginInfo = httpContextAccessor.HttpContext.GetUserInformation();
            entity.LastModifyUserId = loginInfo?.Id ?? 0;
            entity.LastModifyTime = DateTime.Now;
        }

        protected virtual void RemoveEntity(TEnitity entity)
        {
            var loginInfo = httpContextAccessor.HttpContext.GetUserInformation();
            entity.DeleteUserId = loginInfo.Id;
            entity.DeleteTime = DateTime.Now;
        }
    }
}
