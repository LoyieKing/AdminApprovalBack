using Data.Entity.SystemManage;
using Data.IRepository.SystemManage;
using Microsoft.AspNetCore.Http;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdminApprovalBack.Services.SystemManage
{
    public class OrganizeApp : AppService
    {
        private readonly IOrganizeRepository organizeRepository;

        public OrganizeApp(IOrganizeRepository organizeRepository, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.organizeRepository = organizeRepository;
        }

        public List<OrganizeEntity> GetList()
        {
            return organizeRepository.IQueryable().OrderBy(t => t.F_CreatorTime).ToList();
        }
        public OrganizeEntity GetForm(string keyValue)
        {
            return organizeRepository.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            if (organizeRepository.IQueryable().Any(t => t.F_ParentId.Equals(keyValue)))
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                organizeRepository.Delete(t => t.F_Id == keyValue);
            }
        }
        public void SubmitForm(OrganizeEntity organizeEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                ModifyEntity(organizeEntity, keyValue);
                organizeRepository.Update(organizeEntity);
            }
            else
            {
                CreateEntity(organizeEntity);
                organizeRepository.Insert(organizeEntity);
            }
        }
    }
}
