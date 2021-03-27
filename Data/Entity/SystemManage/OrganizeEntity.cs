
using System;
using System.Collections.Generic;
using Data.Infrastructure;

namespace Data.Entity.SystemManage
{
    public class OrganizeEntity : IEntity
    {
        /// <summary>
        /// 父级组织ID
        /// </summary>
        public int? ParentId { get; set; }
        public OrganizeEntity? Parent { get; set; }
        public List<OrganizeEntity> SubOrganizes { get; set; } = null!;

        /// <summary>
        /// 中文名称
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// 分类
        /// </summary>
        public int CategoryId { get; set; }
        public OrganizeCategoryEntity Category { get; set; } = null!;

        public List<UserOrganizeEntity> Users { get; set; } = null!;
    }
}