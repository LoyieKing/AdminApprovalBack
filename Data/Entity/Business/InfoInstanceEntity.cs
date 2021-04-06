using Data.Entity.Approval;
using Data.Entity.SystemManage;
using Data.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity.Business
{
    public class InfoInstanceEntity : IEntity
    {
        public virtual UserEntity User { get; set; }
        public virtual InfoClassEntity InfoClass { get; set; }
        public string Value { get; set; }
        public string Status { get; set; }
    }

    class InfoInstanceMap : EntityTypeConfiguration<InfoInstanceEntity>
    {
        public override void Configure(EntityTypeBuilder<InfoInstanceEntity> builder)
        {
            base.Configure(builder);
            builder.HasOne(it => it.User).WithMany(it => it.InfoInstances);
        }
    }
}
