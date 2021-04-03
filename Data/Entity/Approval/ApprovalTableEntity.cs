using Data.Entity.SystemManage;
using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity.Approval
{
    public class ApprovalTableEntity : IEntity
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public List<InfoGroupEntity> InfoGroups { get; set; }
        public OrganizeEntity OwnerOrganize { get; set; }
    }

    class AppprovalTableMap : EntityTypeConfiguration<ApprovalTableEntity>
    {

    }
}
