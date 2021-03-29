using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApprovalBack.Models
{
    public class OrganizeCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrganizeId { get; set; }
    }
}
