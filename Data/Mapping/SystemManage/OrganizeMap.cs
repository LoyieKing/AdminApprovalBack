

using Data.Entity.SystemManage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.SystemManage
{
    public class OrganizeMap : IEntityTypeConfiguration<OrganizeEntity>
    {
        public void Configure(EntityTypeBuilder<OrganizeEntity> builder)
        {
            builder.ToTable("Sys_Organize");
            builder.HasKey(t => t.F_Id);
        }
    }
}
