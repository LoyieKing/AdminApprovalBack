

using Data.Entity.SystemManage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.SystemManage
{
    public class ModuleMap : IEntityTypeConfiguration<ModuleEntity>
    {
        public void Configure(EntityTypeBuilder<ModuleEntity> builder)
        {
            builder.ToTable("Sys_Module");
            builder.HasKey(t => t.F_Id);
        }
    }
}
