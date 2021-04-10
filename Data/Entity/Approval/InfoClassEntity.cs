using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity.Approval
{
    public class InfoClassEntity : IEntity
    {
        public string Name { get; set; } = null!;
        public int ExpiredDays { get; set; }
        public string InputType { get; set; } = null!;
        public string Category { get; set; } = null!;
        public bool Reusable { get; set; }
        public virtual List<ApprovalTableEntity> ApprovalTables { get; set; }
        public virtual List<ApprovalTableInfoClassEntity> ApprovalTableInfoClassEntities { get; set; }

    }

    class InfoClassMap : EntityTypeConfiguration<InfoClassEntity>
    {
    }
}