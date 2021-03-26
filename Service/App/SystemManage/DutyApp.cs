using Data.Entity.SystemManage;
using Data.IRepository.SystemManage;
using Microsoft.AspNetCore.Http;
using Service;
using System.Collections.Generic;
using System.Linq;

namespace AdminApprovalBack.Services.SystemManage
{
    public class DutyApp : AppService<IRoleRepository,RoleEntity>
    {
        public DutyApp(IRoleRepository roleRepository, IHttpContextAccessor httpContextAccessor) 
            : base(roleRepository, httpContextAccessor) { }

        public IQueryable<RoleEntity> GetList(string keyword = "")
        {
            if (keyword == null) keyword = "";
            return GetList().Where(it => (it.F_FullName.Contains(keyword) || it.F_EnCode.Contains(keyword)) && it.F_Category == 2).OrderBy(t => t.F_SortCode);
        }

        protected override void CreateEntity(RoleEntity entity)
        {
            base.CreateEntity(entity);
            if(entity.F_Category == null)
            {
                entity.F_Category = 2;
            }
        }
    }
}
