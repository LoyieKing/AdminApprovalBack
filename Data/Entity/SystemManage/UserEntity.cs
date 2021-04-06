
using System;
using System.Collections.Generic;
using Data.Entity.Business;
using Data.Infrastructure;

namespace Data.Entity.SystemManage
{
    public class UserEntity : IEntity
    {
        public string UserName { get; set; } = null!;
        public string RealName { get; set; } = null!;
        public string? Avatar { get; set; } = null!;
        public bool? Gender { get; set; }
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 联系方式，推荐为json
        /// </summary>
        public string Contract { get; set; } = null!;

        /// <summary>
        /// 是否为管理员
        /// </summary>
        public bool? IsAdministrator { get; set; }
        public bool? EnabledMark { get; set; }
        public string Password { get; set; } = null!;

        public virtual List<UserOrganizeEntity> Organizes { get; set; } = null!;
        public virtual List<InfoInstanceEntity> InfoInstances { get; set; } = null!;
    }

    class UserMap : EntityTypeConfiguration<UserEntity> { }
}
