using Data.Entity.SystemManage;
using Data.Infrastructure;

namespace Data.Entity.Approval
{
    public class ApprovalTableOrganizeEntity : IEntity
    {
        public virtual ApprovalTableEntity ApprovalTable { get; set; }
        public virtual OrganizeEntity Organize { get; set; }
    }

    class ApprovalTableOrganizeMap : EntityTypeConfiguration<ApprovalTableOrganizeEntity>
    {
    }
}