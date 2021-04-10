using Data.Entity.Approval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApprovalBack.Models
{
    public class ApprovalTableModel : IModel<ApprovalTableModel, ApprovalTableEntity>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public List<int>? InfoClasses { get; set; }
        public List<int>? OwnerOrganizes { get; set; }

        protected override void OnFromEntity(ApprovalTableEntity entity)
        {
            base.OnFromEntity(entity);
            InfoClasses = entity.InfoClasses.Select(it => it.Id).ToList();
            OwnerOrganizes = entity.OwnerOrganizes.Select(it => it.Id).ToList();
        }
        
    }
}