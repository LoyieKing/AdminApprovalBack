using Data.Entity.Approval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApprovalBack.Models
{
    public class ApprovalTableModel : IModel<ApprovalTableModel, ApprovalTableEntity>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public List<InfoRowGroupModel> InfoRowGroups { get; set; }

        protected override void OnFromEntity(ApprovalTableEntity entity)
        {
            base.OnFromEntity(entity);
            InfoRowGroups = entity.InfoGroups.Select(it => new InfoRowGroupModel
            {
                Name = it.Name,
                Rows = it.Items.Select(it =>
                new NamedInfoItemModel
                {
                    Name = it.Name,
                    InfoItem = new InfoClassModel().FromEntity(it.Item)
                }).ToList()
            }).ToList();
        }

        public override ApprovalTableEntity ToEntity()
        {
            var result = base.ToEntity();
            result.InfoGroups = InfoRowGroups?.Select(it =>
            {
                var group = new InfoGroupEntity
                {
                    Name = it.Name
                };
                group.Items = it.Rows.Select(row => new InfoGroupItemEntity { Name = row.Name, Group = group, Item = row.InfoItem.ToEntity() }).ToList();
                return group;
            }).ToList() ?? new List<InfoGroupEntity>();
            return result;
        }
    }

    public class InfoRowGroupModel
    {
        public string Name { get; set; }
        public List<NamedInfoItemModel> Rows { get; set; }
    }

    public class NamedInfoItemModel
    {
        public string Name { get; set; }
        public InfoClassModel InfoItem { get; set; }
    }
}
