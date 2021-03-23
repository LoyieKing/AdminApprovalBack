
using Data.Entity.SystemManage;
using Data.IRepository.SystemManage;
using Data.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.SystemManage
{
    public class OrganizeRepository : RepositoryBase<OrganizeEntity>, IOrganizeRepository
    {
        public OrganizeRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
