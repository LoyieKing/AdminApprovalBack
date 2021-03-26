using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Data.Infrastructure
{
    public abstract class IEntity<TEntity>
    {
        public string F_Id { get; set; }
        public string F_CreatorUserId { get; set; }
        public DateTime? F_CreatorTime { get; set; }

        /// <summary>
        /// 逻辑删除标记
        /// </summary>
        public bool? F_DeleteMark { get; set; }

        /// <summary>
        /// 删除实体的用户
        /// </summary>
        public string F_DeleteUserId { get; set; }

        /// <summary>
        /// 删除实体时间
        /// </summary>
        public DateTime? F_DeleteTime { get; set; }

        public string F_LastModifyUserId { get; set; }
        public DateTime? F_LastModifyTime { get; set; }
    }
}