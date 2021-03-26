using Data.Entity.SystemManage;
using Data.IRepository.SystemManage;
using Microsoft.AspNetCore.Http;
using Service;
using System;
using System.Linq;

namespace AdminApprovalBack.Services.SystemManage
{
    public class ModuleButtonApp : AppService<IModuleButtonRepository,ModuleButtonEntity>
    {

        public ModuleButtonApp(IModuleButtonRepository moduleButtonRepository, IHttpContextAccessor httpContextAccessor)
            : base(moduleButtonRepository, httpContextAccessor) { }

        public IQueryable<ModuleButtonEntity> GetList(string moduleId = "")
        {
            var query = repo.IQueryable();
            if (!string.IsNullOrEmpty(moduleId))
            {
                query = query.Where(it => it.F_ModuleId == moduleId);
            }
            return query.OrderBy(t => t.F_SortCode);
        }
        public override void DeleteForm(string keyValue)
        {
            if (repo.IQueryable().Any(t => t.F_ParentId.Equals(keyValue)))
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            base.DeleteForm(keyValue);
        }
        public void SubmitCloneButton(string moduleId, params string[] ids)
        {
            var data = this.GetList();
            var entities = data.Where(it => ids.Any(id => it.F_Id == id)).ToList().Select(it =>
            {
                it.F_Id = Common.Utils.GuId();
                it.F_ModuleId = moduleId;
                return it;
            });
            repo.Insert(entities);
        }
    }
}
