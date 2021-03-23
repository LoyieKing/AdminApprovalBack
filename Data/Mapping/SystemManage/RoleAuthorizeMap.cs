

using Data.Entity.SystemManage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.SystemManage
{
    public class RoleAuthorizeMap : IEntityTypeConfiguration<RoleAuthorizeEntity>
    {
        public void Configure(EntityTypeBuilder<RoleAuthorizeEntity> builder)
        {
            builder.ToTable("Sys_RoleAuthorize");
            builder.HasKey(t => t.F_Id);
        }
    }
}
