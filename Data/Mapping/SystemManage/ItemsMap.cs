
using Data.Entity.SystemManage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.SystemManage
{
    public class ItemsMap : IEntityTypeConfiguration<ItemsEntity>
    {
        public void Configure(EntityTypeBuilder<ItemsEntity> builder)
        {
            builder.ToTable("Sys_Items");
            builder.HasKey(t => t.F_Id);
        }
    }
}
