using Data.Entity.SystemManage;
using Data.IRepository.SystemManage;
using Microsoft.EntityFrameworkCore;
using Data.RepositoryBase;


namespace Data.Repository.SystemManage
{
    public class ItemsRepository : RepositoryBase<ItemsEntity>, IItemsRepository
    {
        public ItemsRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}