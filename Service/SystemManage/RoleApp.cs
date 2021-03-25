using Data.Entity.SystemManage;
using Data.IRepository.SystemManage;
using Microsoft.AspNetCore.Http;
using Service;
using System.Collections.Generic;
using System.Linq;

namespace AdminApprovalBack.Services.SystemManage
{
    public class RoleApp : AppService
    {
        private readonly IRoleRepository roleRepository;
        private readonly ModuleApp moduleApp;
        private readonly ModuleButtonApp moduleButtonApp;

        public RoleApp(IRoleRepository roleRepository,ModuleApp moduleApp,ModuleButtonApp moduleButtonApp,IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.roleRepository = roleRepository;
            this.moduleApp = moduleApp;
            this.moduleButtonApp = moduleButtonApp;
        }

        public List<RoleEntity> GetList(string keyword = "")
        {
            var query = roleRepository.IQueryable();
            query = query.Where(it => it.F_Category == 1);
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(it => it.F_FullName.Contains(keyword) || it.F_EnCode.Contains(keyword));
            }
            return query.OrderBy(t => t.F_SortCode).ToList();
        }
        public RoleEntity GetForm(string keyValue)
        {
            return roleRepository.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            roleRepository.DeleteForm(keyValue);
        }
        public void SubmitForm(RoleEntity roleEntity, string[] permissionIds, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                roleEntity.F_Id = keyValue;
            }
            else
            {
                roleEntity.F_Id = Common.Utils.GuId();
            }
            var moduledata = moduleApp.GetList();
            var buttondata = moduleButtonApp.GetList();
            List<RoleAuthorizeEntity> roleAuthorizeEntitys = new List<RoleAuthorizeEntity>();
            foreach (var itemId in permissionIds)
            {
                RoleAuthorizeEntity roleAuthorizeEntity = new RoleAuthorizeEntity();
                roleAuthorizeEntity.F_Id = Common.Utils.GuId();
                roleAuthorizeEntity.F_ObjectType = 1;
                roleAuthorizeEntity.F_ObjectId = roleEntity.F_Id;
                roleAuthorizeEntity.F_ItemId = itemId;
                if (moduledata.Find(t => t.F_Id == itemId) != null)
                {
                    roleAuthorizeEntity.F_ItemType = 1;
                }
                if (buttondata.Find(t => t.F_Id == itemId) != null)
                {
                    roleAuthorizeEntity.F_ItemType = 2;
                }
                roleAuthorizeEntitys.Add(roleAuthorizeEntity);
            }
            roleRepository.SubmitForm(roleEntity, roleAuthorizeEntitys, keyValue);
        }
    }
}
