using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity.SystemManage
{
    public class OrganizeCategoryEntity : IEntity
    {
        public enum Categories
        {
            Main,
            Short
        }

        public string Name { get; set; } = null!;
        public Categories Category { get; set; }

        public List<OrganizeEntity> Organizes { get; set; } = null!;
    }
}
