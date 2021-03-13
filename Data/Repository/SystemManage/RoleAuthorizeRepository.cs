using Data.Entity.SystemManage;
using Data.IRepository.SystemManage;
using Data.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.SystemManage
{
    public class RoleAuthorizeRepository : RepositoryBase<RoleAuthorizeEntity>, IRoleAuthorizeRepository
    {
        public RoleAuthorizeRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
