using Data.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity.SystemManage
{
    public class RoleMenuEntity : IEntity
    {
        public RoleEntity Role { get; set; } = null!;
        public MenuEntity Menu { get; set; } = null!;
    }

    class RoleMenuMap : EntityTypeConfiguration<RoleMenuEntity>
    {
        public override void Configure(EntityTypeBuilder<RoleMenuEntity> builder)
        {
            base.Configure(builder);
            
            builder.HasOne(it => it.Role).WithMany(it => it.AvailableMenus);
            builder.HasOne(it => it.Menu).WithMany();
        }
    }
}
