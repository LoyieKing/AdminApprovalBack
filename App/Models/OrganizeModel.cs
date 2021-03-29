using Data.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApprovalBack.Models
{
    public class OrganizeModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
        public IEnumerable<OrganizeModel> SubOrganizes { get; set; } = null!;
    }

    public static class OrganizeModelExtension
    {
        public static OrganizeModel ToOrganizeModel(this OrganizeEntity organizeEntity)
        {
            return new OrganizeModel
            {
                Id = organizeEntity.Id,
                Name = organizeEntity.Name,
                CategoryId = organizeEntity.CategoryId,
                SubOrganizes = organizeEntity.SubOrganizes.Select(it => it.ToOrganizeModel())
            };
        }
    }
}
