
using Data.Entity.SystemManage;
using Data.RepositoryBase;

namespace Data.IRepository.SystemManage
{
    public interface IUserRepository : IRepositoryBase<UserEntity>
    {
        void Delete(string keyValue);
        void Submit(UserEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue);
    }
}
