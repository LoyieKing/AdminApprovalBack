using Data.Entity.SystemManage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.SystemManage
{
    class OrganizeCategoryMap : IEntityTypeConfiguration<OrganizeCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<OrganizeCategoryEntity> builder)
        {
            builder.HasIndex(it => it.Id);
        }
    }
}
