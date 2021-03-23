using Data.Entity.SystemManage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.SystemManage
{
    public class AreaMap : IEntityTypeConfiguration<AreaEntity>
    {
        public void Configure(EntityTypeBuilder<AreaEntity> builder)
        {
            builder.ToTable("Sys_Area");
            builder.HasKey(t => t.F_Id);
        }
    }
}
