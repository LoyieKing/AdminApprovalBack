using Data.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity.Approval
{
    public class InfoGroupItemEntity : IEntity
    {
        public virtual InfoGroupEntity Group { get; set; }
        public virtual InfoClassEntity Item { get; set; }
        public string Name { get; set; }
    }

    class InfoGroupItemMap : EntityTypeConfiguration<InfoGroupItemEntity>
    {
        public override void Configure(EntityTypeBuilder<InfoGroupItemEntity> builder)
        {
            base.Configure(builder);
            builder.HasOne(it => it.Group).WithMany(it => it.Items);
        }
    }
}
