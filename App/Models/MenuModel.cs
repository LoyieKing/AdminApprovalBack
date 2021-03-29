using Data.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApprovalBack.Models
{
    public class MenuModel
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
    }

    public static class MenuModelExtension
    {
        public static MenuModel ToMenuModel(this MenuEntity menuEntity)
        {
            return new MenuModel
            {
                Id = menuEntity.Id,
                Name = menuEntity.Name,
                Icon = menuEntity.Icon,
                BasePath = menuEntity.BasePath,
                Path = menuEntity.Path,
                Url = menuEntity.Url,
                Priority = menuEntity.Priority,
                Target = menuEntity.Target,
                Children = menuEntity.Children.Select(it => menuEntity.ToMenuModel())
            };
        }

        public static MenuEntity ToMenuEntity(this MenuModel menuModel)
        {
            return new MenuEntity
            {
                Id = menuModel.Id,
                Name = menuModel.Name,
                Icon = menuModel.Icon,
                BasePath = menuModel.BasePath,
                Path = menuModel.Path,
                Url = menuModel.Url,
                Priority = menuModel.Priority,
                Target = menuModel.Target
            };
        }
    }
}
