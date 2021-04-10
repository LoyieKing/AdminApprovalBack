using Data.Infrastructure;

namespace Data.Entity.Approval
{
    public class ApprovalTableInfoClassEntity : IEntity
    {
        public virtual ApprovalTableEntity ApprovalTable { get; set; }
        public virtual InfoClassEntity InfoClass { get; set; }
    }

    class ApprovalTableInfoClassMap : EntityTypeConfiguration<ApprovalTableEntity>
    {
    }
}