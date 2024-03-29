﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Infrastructure
{
    abstract class EntityTypeConfiguration<T> : IEntityTypeConfiguration<T>
        where T : IEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasOne(it => it.LastModifyUser).WithMany().HasForeignKey(it => it.LastModifyUserId).IsRequired(false);
            builder.HasOne(it => it.CreatorUser).WithMany().HasForeignKey(it => it.CreatorUserId).IsRequired(false);
            builder.HasOne(it => it.DeleteUser).WithMany().HasForeignKey(it => it.DeleteUserId).IsRequired(false);
        }

    }
}
