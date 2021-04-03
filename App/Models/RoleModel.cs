using Data.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApprovalBack.Models
{
    public class RoleModel : IModel<RoleModel, RoleEntity>
    {
        public int Id { get; set; }
        public string? Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public int OrganizeCategoryId { get; set; }
        public int? OrganizeDutyLevel { get; set; }
        public IEnumerable<int>? AvailableMenuIds { get; set; } = null!;

        protected override void OnFromEntity(RoleEntity entity)
        {
            base.OnFromEntity(entity);
            OrganizeDutyLevel = entity.OrganizeDutyLevel;
            AvailableMenuIds = entity.AvailableMenus.Select(it => it.Id);
        }
    }
}
