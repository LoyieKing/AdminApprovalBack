
using System;
using Data.Infrastructure;

namespace Data.Entity.SystemManage
{
    public class RoleAuthorizeEntity : IEntity<RoleAuthorizeEntity>
    {
        public int? F_ItemType { get; set; }
        public string F_ItemId { get; set; }
        public int? F_ObjectType { get; set; }
        public string F_ObjectId { get; set; }
        public int? F_SortCode { get; set; }
    }
}
