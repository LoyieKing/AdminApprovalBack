using Data.Entity.SystemManage;
using Data.IRepository.SystemManage;
using Microsoft.EntityFrameworkCore;
using Data.RepositoryBase;


namespace Data.Repository.SystemManage
{
    public class AreaRepository : RepositoryBase<AreaEntity>, IAreaRepository
    {
        public AreaRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}