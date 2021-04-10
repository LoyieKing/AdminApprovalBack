using System;
using Data.Entity.SystemManage;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AdminApprovalBack.Models
{
    public class UserModel : IModel<UserModel, UserEntity>
    {
        public int Id { get; set; }
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
    }
}