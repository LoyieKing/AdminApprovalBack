
using Data.Entity.SystemSecurity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.SystemSecurity
{
    public class LogMap : IEntityTypeConfiguration<LogEntity>
    {
        public void Configure(EntityTypeBuilder<LogEntity> builder)
        {
            builder.ToTable("Sys_Log");
            builder.HasIndex(t => t.Id);
        }
    }
}
