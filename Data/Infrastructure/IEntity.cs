using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Data.Infrastructure
{
    public abstract class IEntity
    {
        public int Id { get; set; } = -1;
        public int CreatorUserId { get; set; }
        public DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 删除实体的用户
        /// </summary>
        public int DeleteUserId { get; set; }
        /// <summary>
        /// 删除实体时间
        /// </summary>
        public DateTime? DeleteTime { get; set; }

        public int LastModifyUserId { get; set; }
        public DateTime? LastModifyTime { get; set; }
    }
}