using Data.Entity.SystemManage;
using Data.IRepository.SystemManage;
using Data.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.SystemManage
{
    public class ModuleRepository : RepositoryBase<ModuleEntity>, IModuleRepository
    {
        public ModuleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
