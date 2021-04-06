using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entity.SystemManage;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;

namespace Data.Infrastructure
{
    public abstract class IEntity
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int? CreatorUserId { get; set; }
        public virtual UserEntity? CreatorUser { get; set; }

        public DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 删除实体的用户
        /// </summary>
        public int? DeleteUserId { get; set; }
        public virtual UserEntity? DeleteUser { get; set; }

        /// <summary>
        /// 删除实体时间
        /// </summary>
        public DateTime? DeleteTime { get; set; }

        public int? LastModifyUserId { get; set; }
        public virtual UserEntity? LastModifyUser { get; set; }
        public DateTime? LastModifyTime { get; set; }
    }
}