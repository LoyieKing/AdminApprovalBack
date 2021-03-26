using Common.Encrypt;
using Common.Query;
using Data.Entity.SystemManage;
using Data.IRepository.SystemManage;
using Microsoft.AspNetCore.Http;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdminApprovalBack.Services.SystemManage
{
    public class UserApp : AppService<IUserRepository,UserEntity>
    {
        private readonly UserLogOnApp userLogOnApp;

        public UserApp(IUserRepository userRepository, UserLogOnApp userLogOnApp, IHttpContextAccessor httpContextAccessor) 
            : base(userRepository, httpContextAccessor)
        {
            this.userLogOnApp = userLogOnApp;
        }

        public IQueryable<UserEntity> GetList(Pagination pagination, string keyword)
        {
            var query = GetList();
            query = query.Where(it => it.F_Account != "admin");
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(it => it.F_Account.Contains(keyword) || it.F_RealName.Contains(keyword) || it.F_MobilePhone.Contains(keyword));
            }
            return query.PaginationBy(pagination);
        }

        public void Submit(UserEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                ModifyEntity(userEntity, keyValue);
            }
            else
            {
                CreateEntity(userEntity);
            }
            repo.Submit(userEntity, userLogOnEntity, keyValue);
        }
        public void Update(UserEntity userEntity)
        {
            repo.Update(userEntity);
        }
        public UserEntity CheckLogin(string username, string password)
        {
            UserEntity userEntity = repo.FindEntity(t => t.F_Account == username);
            if (userEntity == null)
            {
                throw new Exception("账户不存在，请重新输入");
            }
            if (userEntity.F_EnabledMark == false)
            {
                throw new Exception("账户被系统锁定,请联系管理员");
            }

            UserLogOnEntity userLogOnEntity = userLogOnApp.FineOne(userEntity.F_Id);
            string dbPassword = Md5.Hash(DesEncrypt.Encrypt(password, userLogOnEntity.F_UserSecretkey).ToLower(), 32).ToLower();
            if (dbPassword == userLogOnEntity.F_UserPassword)
            {
                DateTime lastVisitTime = DateTime.Now;
                if (userLogOnEntity.F_LastVisitTime != null)
                {
                    userLogOnEntity.F_PreviousVisitTime = userLogOnEntity.F_LastVisitTime ?? DateTime.UnixEpoch;
                }
                userLogOnEntity.F_LastVisitTime = lastVisitTime;
                userLogOnApp.Update(userLogOnEntity);
                return userEntity;
            }
            else
            {
                throw new Exception("密码不正确，请重新输入");
            }
        }
    }
}
