﻿using Data.Entity.SystemManage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping.SystemManage
{
    class OrganizeMap : IEntityTypeConfiguration<OrganizeEntity>
    {
        public void Configure(EntityTypeBuilder<OrganizeEntity> builder)
        {
            builder.HasIndex(it => it.Id);
            builder.HasOne(it => it.Category).WithMany(it => it.Organizes).HasForeignKey(it => it.CategoryId);
            builder.HasOne(it => it.Parent).WithMany(it => it.SubOrganizes).HasForeignKey(it => it.ParentId);
        }
    }
}
