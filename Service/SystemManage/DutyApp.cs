using Data.Entity.SystemManage;
using Data.IRepository.SystemManage;
using Microsoft.AspNetCore.Http;
using Service;
using System.Collections.Generic;
using System.Linq;

namespace AdminApprovalBack.Services.SystemManage
{
    public class DutyApp : AppService
    {
        private readonly IRoleRepository roleRepository;

        public DutyApp(IRoleRepository roleRepository, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.roleRepository = roleRepository;
        }

        public List<RoleEntity> GetList(string keyword = "")
        {
            if (keyword == null) keyword = "";
            return roleRepository.IQueryable(it => (it.F_FullName.Contains(keyword) || it.F_EnCode.Contains(keyword)) && it.F_Category == 2).OrderBy(t => t.F_SortCode).ToList();
        }
        public RoleEntity GetForm(string keyValue)
        {
            return roleRepository.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            roleRepository.Delete(t => t.F_Id == keyValue);
        }
        public void SubmitForm(RoleEntity roleEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                ModifyEntity(roleEntity, keyValue);
                roleRepository.Update(roleEntity);
            }
            else
            {
                CreateEntity(roleEntity);
                roleEntity.F_Category = 2;
                roleRepository.Insert(roleEntity);
            }
        }
    }
}
