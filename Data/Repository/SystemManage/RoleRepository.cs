using System.Collections.Generic;
using Data.Entity.SystemManage;
using Data.IRepository.SystemManage;
using Data.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.SystemManage
{
    public class RoleRepository : RepositoryBase<RoleEntity>, IRoleRepository
    {
        readonly IRoleAuthorizeRepository roleAuthorizeRepository;
        public RoleRepository(DbContext dbContext, IRoleAuthorizeRepository roleAuthorizeRepository) : base(dbContext)
        {
            this.roleAuthorizeRepository = roleAuthorizeRepository;
        }

        public void Delete(string keyValue)
        {
            using var transaction = DbContext.Database.BeginTransaction();
            DbContext.Remove(new RoleEntity { F_Id = keyValue });
            DbContext.Remove(new RoleAuthorizeEntity { F_ObjectId = keyValue });
            transaction.Commit();
        }

        public void Submit(RoleEntity roleEntity, List<RoleAuthorizeEntity> roleAuthorizeEntities, string keyValue)
        {
            using var transaction = DbContext.Database.BeginTransaction();
            if (!string.IsNullOrEmpty(keyValue))
            {
                Update(roleEntity);
            }
            else
            {
                roleEntity.F_Category = 1;
                Insert(roleEntity);
            }
            roleAuthorizeRepository.Delete(new RoleAuthorizeEntity { F_ObjectId = roleEntity.F_Id });
            roleAuthorizeRepository.Insert(roleAuthorizeEntities);
            transaction.Commit();
        }

    }
}