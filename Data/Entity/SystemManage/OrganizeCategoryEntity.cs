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

        public virtual string Name { get; set; } = null!;
        public virtual Categories Category { get; set; }

        public virtual List<OrganizeEntity> Organizes { get; set; } = null!;
    }
}
