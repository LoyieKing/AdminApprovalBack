using Data.Entity.SystemManage;
using Data.IRepository.SystemManage;
using Microsoft.AspNetCore.Http;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdminApprovalBack.Services.SystemManage
{
    public class ItemsApp : AppService
    {
        private readonly IItemsRepository service;

        public ItemsApp(IItemsRepository itemsRepository, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.service = itemsRepository;
        }

        public List<ItemsEntity> GetList()
        {
            return service.IQueryable().ToList();
        }
        public ItemsEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            if (service.IQueryable().Count(t => t.F_ParentId.Equals(keyValue)) > 0)
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                service.Delete(t => t.F_Id == keyValue);
            }
        }
        public void SubmitForm(ItemsEntity itemsEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                ModifyEntity(itemsEntity, keyValue);
                service.Update(itemsEntity);
            }
            else
            {
                CreateEntity(itemsEntity);
                service.Insert(itemsEntity);
            }
        }
    }
}
