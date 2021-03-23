
using System.Collections.Generic;
using Data.Entity.SystemManage;
using Data.RepositoryBase;

namespace Data.IRepository.SystemManage
{
    public interface IRoleRepository : IRepositoryBase<RoleEntity>
    {
        void DeleteForm(string keyValue);
        void SubmitForm(RoleEntity roleEntity, List<RoleAuthorizeEntity> roleAuthorizeEntities, string keyValue);
    }
}
