using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entity.SystemManage;

namespace AdminApprovalBack.Models
{
    public class OrganizeCategoryModel : IModel<OrganizeCategoryModel, OrganizeCategoryEntity>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public OrganizeCategoryEntity.Categories Category { get; set; }
    }
}