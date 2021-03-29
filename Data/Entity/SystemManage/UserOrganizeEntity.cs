using Data.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entity.SystemManage
{
    public class UserOrganizeEntity : IEntity
    {
        public UserEntity User { get; set; } = null!;
        public OrganizeEntity Organize { get; set; } = null!;
        public int DutyLevel { get; set; }
    }

    class UserOrganizeMap : EntityTypeConfiguration<UserOrganizeEntity>
    {
        public override void Configure(EntityTypeBuilder<UserOrganizeEntity> builder)
        {
            base.Configure(builder);
            builder.HasOne(it => it.User).WithMany(it => it.Organizes);
            builder.HasOne(it => it.Organize).WithMany(it => it.Users);
        }
    }
}
