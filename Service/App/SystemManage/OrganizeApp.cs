using Data.Entity.SystemManage;
using Data.IRepository.SystemManage;
using Microsoft.AspNetCore.Http;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdminApprovalBack.Services.SystemManage
{
    public class OrganizeApp : AppService<IOrganizeRepository,OrganizeEntity>
    {
        public OrganizeApp(IOrganizeRepository organizeRepository, IHttpContextAccessor httpContextAccessor)
            : base(organizeRepository, httpContextAccessor) { }

        public override IQueryable<OrganizeEntity> GetList()
        {
            return base.GetList().OrderBy(t => t.F_CreatorTime);
        }
        public override void Delete(string keyValue)
        {
            if (repo.IQueryable().Any(t => t.F_ParentId.Equals(keyValue)))
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            base.Delete(keyValue);
        }
    }
}
