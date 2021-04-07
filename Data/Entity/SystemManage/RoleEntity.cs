using Data.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity.SystemManage
{
    public class RoleEntity : IEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int OrganizeCategoryId { get; set; }
        public virtual OrganizeCategoryEntity OrganizeCategory { get; set; } = null!;
        public int OrganizeDutyLevel { get; set; }

        public virtual String AvailableMenus { get; set; } = null!;
        public virtual String AvailableApprovals { get; set; } = null!;
    }

    class RoleMap : EntityTypeConfiguration<RoleEntity>
    {
        public override void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            base.Configure(builder);
            builder.HasOne(it => it.OrganizeCategory).WithMany().HasForeignKey(it => it.OrganizeCategoryId);
        }
    }
}