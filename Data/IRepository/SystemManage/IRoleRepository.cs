
using System.Collections.Generic;
using Data.Entity.SystemManage;
using Data.RepositoryBase;

namespace Data.IRepository.SystemManage
{
    public interface IRoleRepository : IRepositoryBase<RoleEntity>
    {
        void Delete(string keyValue);
        void Submit(RoleEntity roleEntity, List<RoleAuthorizeEntity> roleAuthorizeEntities, string keyValue);
    }
}
