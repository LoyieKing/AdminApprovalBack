using Data.Entity.SystemManage;
using Data.IRepository.SystemManage;
using Microsoft.AspNetCore.Http;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdminApprovalBack.Services.SystemManage
{
    public class ModuleButtonApp : AppService
    {
        private readonly IModuleButtonRepository service;

        public ModuleButtonApp(IModuleButtonRepository moduleButtonRepository, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.service = moduleButtonRepository;
        }

        public List<ModuleButtonEntity> GetList(string moduleId = "")
        {
            var query = service.IQueryable();
            if (!string.IsNullOrEmpty(moduleId))
            {
                query = query.Where(it => it.F_ModuleId == moduleId);
            }
            return query.OrderBy(t => t.F_SortCode).ToList();
        }
        public ModuleButtonEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            if (service.IQueryable().Any(t => t.F_ParentId.Equals(keyValue)))
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                service.Delete(t => t.F_Id == keyValue);
            }
        }
        public void SubmitForm(ModuleButtonEntity moduleButtonEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                ModifyEntity(moduleButtonEntity, keyValue);
                service.Update(moduleButtonEntity);
            }
            else
            {
                CreateEntity(moduleButtonEntity);
                service.Insert(moduleButtonEntity);
            }
        }
        public void SubmitCloneButton(string moduleId, string Ids)
        {
            string[] ArrayId = Ids.Split(',');
            var data = this.GetList();
            List<ModuleButtonEntity> entitys = new List<ModuleButtonEntity>();
            foreach (string item in ArrayId)
            {
                ModuleButtonEntity moduleButtonEntity = data.Find(t => t.F_Id == item);
                moduleButtonEntity.F_Id = Common.Utils.GuId();
                moduleButtonEntity.F_ModuleId = moduleId;
                entitys.Add(moduleButtonEntity);
            }
            service.SubmitCloneButton(entitys);
        }
    }
}
