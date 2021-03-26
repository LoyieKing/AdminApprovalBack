﻿

using Common.Encrypt;
using Data.Entity.SystemManage;
using Data.IRepository.SystemManage;
using Microsoft.AspNetCore.Http;
using Service;

namespace AdminApprovalBack.Services.SystemManage
{
    public class UserLogOnApp : AppService<IUserLogOnRepository, UserLogOnEntity>
    {

        public UserLogOnApp(IUserLogOnRepository userLogOnRepository, IHttpContextAccessor httpContextAccessor)
            : base(userLogOnRepository, httpContextAccessor) { }

        public void Update(UserLogOnEntity userLogOnEntity)
        {
            repo.Update(userLogOnEntity);
        }
        public void RevisePassword(string userPassword, string keyValue)
        {
            UserLogOnEntity userLogOnEntity = new UserLogOnEntity();
            userLogOnEntity.F_Id = keyValue;
            userLogOnEntity.F_UserSecretkey = Md5.Hash(Common.Utils.CreateNo(), 16).ToLower();
            userLogOnEntity.F_UserPassword = Md5.Hash(DesEncrypt.Encrypt(Md5.Hash(userPassword, 32).ToLower(), userLogOnEntity.F_UserSecretkey).ToLower(), 32).ToLower();
            repo.Update(userLogOnEntity);
        }
    }
}