using Data.Entity.SystemManage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.SystemManage
{
    public class RoleMap : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.ToTable("Sys_Role");
            builder.HasKey(t => t.F_Id);
        }
    }
}
