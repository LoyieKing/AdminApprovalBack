using Common;
using Common.Encrypt;
using Data.Entity.SystemManage;
using Data.IRepository.SystemManage;
using Data.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.SystemManage
{
    public class UserRepository : RepositoryBase<UserEntity>, IUserRepository
    {
        readonly IUserLogOnRepository userLogOnRepository;

        public UserRepository(DbContext dbContext, IUserLogOnRepository userLogOnRepository) : base(dbContext)
        {
            this.userLogOnRepository = userLogOnRepository;
        }
        public void DeleteForm(string keyValue)
        {
            using var transaction = DbContext.Database.BeginTransaction();
            DbContext.Remove(new UserEntity { F_Id = keyValue });
            userLogOnRepository.Delete(new UserLogOnEntity { F_UserId = keyValue });
            transaction.Commit();
        }

        public void SubmitForm(UserEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue)
        {
            using var trans = DbContext.Database.BeginTransaction();

            if (!string.IsNullOrEmpty(keyValue))
            {
                Update(userEntity);
            }
            else
            {
                userLogOnEntity.F_Id = userEntity.F_Id;
                userLogOnEntity.F_UserId = userEntity.F_Id;
                userLogOnEntity.F_UserSecretkey = Md5.Hash(Utils.CreateNo(), 16).ToLower();
                userLogOnEntity.F_UserPassword = Md5.Hash(
                        DesEncrypt.Encrypt(Md5.Hash(userLogOnEntity.F_UserPassword, 32).ToLower(),
                            userLogOnEntity.F_UserSecretkey).ToLower(), 32).ToLower();
                Insert(userEntity);
                userLogOnRepository.Insert(userLogOnEntity);
            }

            trans.Commit();
        }

    }
}