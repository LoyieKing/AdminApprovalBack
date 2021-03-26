using Data.Entity.SystemManage;
using Data.IRepository.SystemManage;
using Data.Repository.SystemManage;
using Microsoft.AspNetCore.Http;
using Service;
using System.Collections.Generic;
using System.Linq;

namespace AdminApprovalBack.Services.SystemManage
{
    public class ItemsDetailApp : AppService<IItemsDetailRepository,ItemsDetailEntity>
    {
        public ItemsDetailApp(IItemsDetailRepository itemsDetailRepository, IHttpContextAccessor httpContextAccessor)
            : base(itemsDetailRepository, httpContextAccessor) { }

        public IQueryable<ItemsDetailEntity> GetList(string itemId = "", string keyword = "")
        {
            var query = repo.IQueryable();
            if (!string.IsNullOrEmpty(itemId))
            {
                query = query.Where(it => it.F_ItemId == itemId);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(it => it.F_ItemName.Contains(keyword) || it.F_ItemCode.Contains(keyword));
            }
            return query.OrderBy(t => t.F_SortCode);
        }
        public List<ItemsDetailEntity> GetItemList(string enCode)
        {
            return repo.GetItemList(enCode);
        }
    }
}