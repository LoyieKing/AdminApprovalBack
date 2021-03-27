

using Data.Entity.SystemSecurity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.SystemSecurity
{
    public class DbBackupMap : IEntityTypeConfiguration<DbBackupEntity>
    {
        public void Configure(EntityTypeBuilder<DbBackupEntity> builder)
        {
            builder.ToTable("Sys_DbBackup");
            builder.HasIndex(t => t.Id);
        }
    }
}
