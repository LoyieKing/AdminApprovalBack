using Data.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApprovalBack.Models
{
    public class MenuModel : IModel<MenuModel, MenuEntity>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public string? BasePath { get; set; }
        public string? Path { get; set; }
        public string? Url { get; set; }
        public int Priority { get; set; }
        public MenuEntity.TargetType? Target { get; set; }
        public IEnumerable<MenuModel> Children { get; set; } = null!;

        protected override void OnFromEntity(MenuEntity entity)
        {
            base.OnFromEntity(entity);
            Children = entity.Children.Select(it => new MenuModel().FromEntity(it));
        }
    }
}
