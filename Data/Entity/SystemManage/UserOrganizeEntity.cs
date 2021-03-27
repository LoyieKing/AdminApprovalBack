using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity.SystemManage
{
    public class UserOrganizeEntity : IEntity
    {
        public UserEntity User { get; set; } = null!;
        public OrganizeEntity Organize { get; set; } = null!;
        public int DutyLevel { get; set; }
    }
}
