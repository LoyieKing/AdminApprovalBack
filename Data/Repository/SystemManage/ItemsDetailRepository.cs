
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Data.Entity.SystemManage;
using Data.IRepository.SystemManage;
using Data.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.SystemManage
{
    public class ItemsDetailRepository : RepositoryBase<ItemsDetailEntity>, IItemsDetailRepository
    {
        public ItemsDetailRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public List<ItemsDetailEntity> GetItemList(string enCode)
        {
            return IQueryable(item => item.Item.F_EnCode == enCode &&
                                           item.F_EnabledMark == true &&
                                           !item.F_DeleteMark == false)
                .OrderBy(d => d.F_SortCode)
                .ToList();
        }
    }
}