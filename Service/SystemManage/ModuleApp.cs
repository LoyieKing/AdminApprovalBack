using Data.Entity.SystemManage;
using Data.IRepository.SystemManage;
using Microsoft.AspNetCore.Http;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdminApprovalBack.Services.SystemManage
{
    public class ModuleApp : AppService
    {
        private readonly IModuleRepository moduleRepository;

        public ModuleApp(IModuleRepository moduleRepository, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.moduleRepository = moduleRepository;
        }

        public List<ModuleEntity> GetList()
        {
            return moduleRepository.IQueryable().OrderBy(t => t.F_SortCode).ToList();
        }
        public ModuleEntity GetForm(string keyValue)
        {
            return moduleRepository.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            if (moduleRepository.IQueryable().Any(t => t.F_ParentId.Equals(keyValue)))
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                moduleRepository.Delete(t => t.F_Id == keyValue);
            }
        }
        public void SubmitForm(ModuleEntity moduleEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                ModifyEntity(moduleEntity, keyValue);
                moduleRepository.Update(moduleEntity);
            }
            else
            {
                CreateEntity(moduleEntity);
                moduleRepository.Insert(moduleEntity);
            }
        }
    }
}
