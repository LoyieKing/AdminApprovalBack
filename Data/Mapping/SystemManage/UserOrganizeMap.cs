using Data.Entity.SystemManage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping.SystemManage
{
    public class UserOrganizeMap : IEntityTypeConfiguration<UserOrganizeEntity>
    {
        public void Configure(EntityTypeBuilder<UserOrganizeEntity> builder)
        {
            builder.HasIndex(it => it.Id);
            builder.HasOne(it => it.User).WithMany(it => it.Organizes);
            builder.HasOne(it => it.Organize).WithMany(it => it.Users);
        }
    }
}
