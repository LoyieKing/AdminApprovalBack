


using Data.Entity.SystemManage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.SystemManage
{
    public class ItemsDetailMap : IEntityTypeConfiguration<ItemsDetailEntity>
    {
        public void Configure(EntityTypeBuilder<ItemsDetailEntity> builder)
        {
            builder.ToTable("Sys_ItemsDetail");
            builder.HasKey(t => t.F_Id);
            builder.HasOne(it => it.Item).WithOne().HasForeignKey<ItemsDetailEntity>(it => it.F_ItemId);
        }
    }
}
