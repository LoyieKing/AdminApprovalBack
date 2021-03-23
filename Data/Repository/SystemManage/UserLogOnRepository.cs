
using Data.Entity.SystemManage;
using Data.IRepository.SystemManage;
using Data.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.SystemManage
{
    public class UserLogOnRepository : RepositoryBase<UserLogOnEntity>, IUserLogOnRepository
    {
        public UserLogOnRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}