using Data.Entity.SystemManage;
using Data.IRepository.SystemManage;
using Microsoft.AspNetCore.Http;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdminApprovalBack.Services.SystemManage
{
    public class AreaApp : AppService
    {
        private readonly IAreaRepository areaRepository;

        public AreaApp(IAreaRepository areaRepository, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.areaRepository = areaRepository;
        }

        public List<AreaEntity> GetList()
        {
            return areaRepository.IQueryable().ToList();
        }
        public AreaEntity GetForm(string keyValue)
        {
            return areaRepository.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            if (areaRepository.IQueryable().Count(t => t.F_ParentId.Equals(keyValue)) > 0)
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                areaRepository.Delete(t => t.F_Id == keyValue);
            }
        }
        public void SubmitForm(AreaEntity areaEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                ModifyEntity(areaEntity, keyValue);
                areaRepository.Update(areaEntity);
            }
            else
            {
                CreateEntity(areaEntity);
                areaRepository.Insert(areaEntity);
            }
        }
    }
}
