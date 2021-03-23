
using System.Collections.Generic;
using Common.Query;
using Data.Entity.SystemManage;
using Data.RepositoryBase;

namespace Data.IRepository.SystemManage
{
    public interface IItemsDetailRepository : IRepositoryBase<ItemsDetailEntity>
    {
        List<ItemsDetailEntity> GetItemList(string encode);
    }
}
