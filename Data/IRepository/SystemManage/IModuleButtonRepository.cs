
using System.Collections.Generic;
using Data.Entity.SystemManage;
using Data.RepositoryBase;

namespace Data.IRepository.SystemManage
{
    public interface IModuleButtonRepository : IRepositoryBase<ModuleButtonEntity>
    {
        void SubmitCloneButton(List<ModuleButtonEntity> entities);
    }
}
