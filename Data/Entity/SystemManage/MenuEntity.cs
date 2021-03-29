using Data.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity.SystemManage
{
    public class MenuEntity : IEntity
    {
        public enum TargetType
        {
            Internal = 0,
            Replace = 1,
            New = 2
        }

        public string Name { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public string? BasePath { get; set; }
        public string? Path { get; set; }
        public string? Url { get; set; }
        public TargetType? Target { get; set; }
        public int Priority { get; set; }
        public int? ParentId { get; set; }
        public MenuEntity? Parent { get; set; }
        public List<MenuEntity> Children { get; set; } = null!;
    }

    class MenuMap : EntityTypeConfiguration<MenuEntity>
    {
        public override void Configure(EntityTypeBuilder<MenuEntity> builder)
        {
            base.Configure(builder);
            builder.HasOne(it => it.Parent).WithMany(it => it.Children).HasForeignKey(it => it.ParentId);
        }
    }
}