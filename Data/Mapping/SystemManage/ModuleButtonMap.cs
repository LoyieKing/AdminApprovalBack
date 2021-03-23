
using Data.Entity.SystemManage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.SystemManage
{
    public class ModuleButtonMap : IEntityTypeConfiguration<ModuleButtonEntity>
    {
        public void Configure(EntityTypeBuilder<ModuleButtonEntity> builder)
        {
            builder.ToTable("Sys_ModuleButton");
            builder.HasKey(t => t.F_Id);
        }
    }
}
