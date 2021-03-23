
using Data.Entity.SystemSecurity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.SystemSecurity
{
    public class FilterIPMap : IEntityTypeConfiguration<FilterIPEntity>
    {
        public void Configure(EntityTypeBuilder<FilterIPEntity> builder)
        {
            builder.ToTable("Sys_FilterIP");
            builder.HasKey(t => t.F_Id);
        }
    }
}
