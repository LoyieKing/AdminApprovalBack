
using System;
using Data.Infrastructure;

namespace Data.Entity.SystemSecurity
{
    public class LogEntity : IEntity
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; } = null!;

        /// <summary>
        /// 操作类型
        /// </summary>
        public string Type { get; set; } = null!;

        /// <summary>
        /// IP地址
        /// </summary>
        public string IPAddress { get; set; } = null!;

        /// <summary>
        /// 操作结果
        /// </summary>
        public bool? Result { get; set; }

        /// <summary>
        /// 操作描述
        /// </summary>
        public string Description { get; set; } = null!;
    }
}
