using Data.Entity.SystemManage;
using Data.IRepository.SystemManage;
using Microsoft.AspNetCore.Http;
using Service;
using System.Collections.Generic;
using System.Linq;

namespace AdminApprovalBack.Services.SystemManage
{
    public class ItemsDetailApp : AppService
    {
        private readonly IItemsDetailRepository itemsDetailRepository;

        public ItemsDetailApp(IItemsDetailRepository itemsDetailRepository, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.itemsDetailRepository = itemsDetailRepository;
        }

        public List<ItemsDetailEntity> GetList(string itemId = "", string keyword = "")
        {
            var query = itemsDetailRepository.IQueryable();
            if (!string.IsNullOrEmpty(itemId))
            {
                query = query.Where(it => it.F_ItemId == itemId);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(it => it.F_ItemName.Contains(keyword) || it.F_ItemCode.Contains(keyword));
            }
            return query.OrderBy(t => t.F_SortCode).ToList();
        }
        public List<ItemsDetailEntity> GetItemList(string enCode)
        {
            return itemsDetailRepository.GetItemList(enCode);
        }
        public ItemsDetailEntity GetForm(string keyValue)
        {
            return itemsDetailRepository.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            itemsDetailRepository.Delete(t => t.F_Id == keyValue);
        }
        public void SubmitForm(ItemsDetailEntity itemsDetailEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                ModifyEntity(itemsDetailEntity, keyValue);
                itemsDetailRepository.Update(itemsDetailEntity);
            }
            else
            {
                CreateEntity(itemsDetailEntity);
                itemsDetailRepository.Insert(itemsDetailEntity);
            }
        }
    }
}