using Data.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApprovalBack.Models
{
    public class RoleModel
    {
        public int Id { get; set; } 
        public string? Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public int OrganizeCategoryId { get; set; }
        public int? OrganizeDutyLevel { get; set; }
        public IEnumerable<int>? AvailableMenuIds { get; set; } = null!;
    }


    public static class RoleModelExtension
    {
        public static RoleModel ToRoleModel(this RoleEntity roleEntity)
        {
            return new RoleModel
            {
                Id = roleEntity.Id,
                Name = roleEntity.Name,
                Description = roleEntity.Description,
                OrganizeCategoryId = roleEntity.OrganizeCategoryId,
                OrganizeDutyLevel = roleEntity.OrganizeDutyLevel,
                AvailableMenuIds = roleEntity.AvailableMenus.Select(it => it.Id)
            };
        }
    }
}
