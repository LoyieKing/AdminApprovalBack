
using Data.Entity.SystemManage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.SystemManage
{
    public class UserLogOnMap : IEntityTypeConfiguration<UserLogOnEntity>
    {
        public void Configure(EntityTypeBuilder<UserLogOnEntity> builder)
        {
            builder.ToTable("Sys_UserLogOn");
            builder.HasKey(t => t.F_Id);
        }
    }
}
