using Data.Entity.Approval;
using Data.Entity.Business;
using Data.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApprovalBack.Models
{
    public class InfoInstanceModel : IModel<InfoInstanceModel, InfoInstanceEntity>
    {
        public int Id { get; set; }
        public InfoClassModel InfoClass { get; set; }
        public string Value { get; set; }
        public string Status { get; set; }
        public DateTime? CreatorTime { get; set; }
        public DateTime? LastModifyTime { get; set; }

        protected override void OnFromEntity(InfoInstanceEntity entity)
        {
            base.OnFromEntity(entity);
        }

        public override InfoInstanceEntity ToEntity()
        {
            var entity = base.ToEntity();
            entity.PrototypeId = InfoClass.Id;
            return entity;
        }
    }
}