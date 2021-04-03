using Data.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApprovalBack.Models
{
    public class OrganizeModel : IModel<OrganizeModel, OrganizeEntity>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
        public IEnumerable<OrganizeModel> SubOrganizes { get; set; } = null!;

        protected override void OnFromEntity(OrganizeEntity entity)
        {
            base.OnFromEntity(entity);
            SubOrganizes = entity.SubOrganizes.Select(it => new OrganizeModel().FromEntity(entity));
        }
    }
}
