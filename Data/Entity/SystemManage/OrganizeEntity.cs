
using System;
using System.Collections.Generic;
using Data.Entity.Approval;
using Data.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entity.SystemManage
{
    public class OrganizeEntity : IEntity
    {
        /// <summary>
        /// 父级组织ID
        /// </summary>
        public int? ParentId { get; set; }
        public OrganizeEntity? Parent { get; set; }
        public List<OrganizeEntity> SubOrganizes { get; set; } = null!;

        /// <summary>
        /// 中文名称
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// 分类
        /// </summary>
        public int CategoryId { get; set; }
        public OrganizeCategoryEntity Category { get; set; } = null!;

        public List<UserOrganizeEntity> Users { get; set; } = null!;

        public List<ApprovalTableEntity> ApprovalTables { get; set; } = null!;
    }

    class OrganizeMap : EntityTypeConfiguration<OrganizeEntity>
    {
        public override void Configure(EntityTypeBuilder<OrganizeEntity> builder)
        {
            base.Configure(builder);
            builder.HasOne(it => it.Category).WithMany(it => it.Organizes).HasForeignKey(it => it.CategoryId);
            builder.HasOne(it => it.Parent).WithMany(it => it.SubOrganizes).HasForeignKey(it => it.ParentId);
            builder.HasMany(it => it.ApprovalTables).WithOne(it => it.OwnerOrganize).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}