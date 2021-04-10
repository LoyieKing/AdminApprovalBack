using Data.Entity.SystemManage;
using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entity.Approval
{
    public class ApprovalTableEntity : IEntity
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public virtual List<InfoClassEntity> InfoClasses { get; set; }
        public virtual List<ApprovalTableInfoClassEntity> ApprovalTableInfoClassEntities { get; set; }
        public virtual List<OrganizeEntity> OwnerOrganizes { get; set; }
        public virtual List<ApprovalTableOrganizeEntity> ApprovalTableOrganizes { get; set; }
    }

    class AppprovalTableMap : EntityTypeConfiguration<ApprovalTableEntity>
    {
        public override void Configure(EntityTypeBuilder<ApprovalTableEntity> builder)
        {
            base.Configure(builder);
            builder
                .HasMany(it => it.InfoClasses)
                .WithMany(it => it.ApprovalTables)
                .UsingEntity<ApprovalTableInfoClassEntity>(
                    atce =>
                        atce.HasOne(it => it.InfoClass)
                            .WithMany(it => it.ApprovalTableInfoClassEntities),
                    atce =>
                        atce.HasOne(it => it.ApprovalTable)
                            .WithMany(it => it.ApprovalTableInfoClassEntities)
                );

            builder
                .HasMany(it => it.OwnerOrganizes)
                .WithMany(it => it.ApprovalTables)
                .UsingEntity<ApprovalTableOrganizeEntity>(
                    atoe =>
                        atoe.HasOne(it => it.Organize)
                            .WithMany(it => it.ApprovalTableOrganizes),
                    atoe =>
                        atoe.HasOne(it => it.ApprovalTable)
                            .WithMany(it => it.ApprovalTableOrganizes)
                );
        }
    }
}