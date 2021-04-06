using Data.Entity.Approval;
using Data.Entity.SystemManage;
using Data.Infrastructure;
using System.Collections.Generic;

namespace Data.Entity.Business
{
    public class ApprovalInstanceEntity : IEntity
    {
        public virtual UserEntity User { get; set; }
        public virtual ApprovalTableEntity AppprovalTable { get; set; }
        public virtual List<InfoInstanceEntity> InfoInstances { get; set; }
        public string Description { get; set; }
        public string State { get; set; }

    }

    class ApprovalInstanceMap : EntityTypeConfiguration<ApprovalInstanceEntity>
    {

    }
}
