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
    public class UserApp : AppService
    {
        private readonly IUserRepository userRepository;
        private readonly UserLogOnApp userLogOnApp;

        public UserApp(IUserRepository userRepository, UserLogOnApp userLogOnApp, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.userRepository = userRepository;
            this.userLogOnApp = userLogOnApp;
        }

        public List<UserEntity> GetList(Pagination pagination, string keyword)
        {
            var query = userRepository.IQueryable();
            query = query.Where(it => it.F_Account != "admin");
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(it => it.F_Account.Contains(keyword) || it.F_RealName.Contains(keyword) || it.F_MobilePhone.Contains(keyword));
            }
            return query.PaginationBy(pagination).ToList();
        }
        public UserEntity GetForm(string keyValue)
        {
            return userRepository.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            userRepository.DeleteForm(keyValue);
        }
        public void SubmitForm(UserEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                ModifyEntity(userEntity, keyValue);
            }
            else
            {
                CreateEntity(userEntity);
            }
            userRepository.SubmitForm(userEntity, userLogOnEntity, keyValue);
        }
        public void UpdateForm(UserEntity userEntity)
        {
            userRepository.Update(userEntity);
        }
        public UserEntity CheckLogin(string username, string password)
        {
            UserEntity userEntity = userRepository.FindEntity(t => t.F_Account == username);
            if (userEntity == null)
            {
                throw new Exception("账户不存在，请重新输入");
            }
            if (userEntity.F_EnabledMark == false)
            {
                throw new Exception("账户被系统锁定,请联系管理员");
            }

            UserLogOnEntity userLogOnEntity = userLogOnApp.GetForm(userEntity.F_Id);
            string dbPassword = Md5.Hash(DesEncrypt.Encrypt(password, userLogOnEntity.F_UserSecretkey).ToLower(), 32).ToLower();
            if (dbPassword == userLogOnEntity.F_UserPassword)
            {
                DateTime lastVisitTime = DateTime.Now;
                int LogOnCount = (userLogOnEntity.F_LogOnCount ?? 0) + 1;
                if (userLogOnEntity.F_LastVisitTime != null)
                {
                    userLogOnEntity.F_PreviousVisitTime = userLogOnEntity.F_LastVisitTime ?? DateTime.UnixEpoch;
                }
                userLogOnEntity.F_LastVisitTime = lastVisitTime;
                userLogOnEntity.F_LogOnCount = LogOnCount;
                userLogOnApp.UpdateForm(userLogOnEntity);
                return userEntity;
            }
            else
            {
                throw new Exception("密码不正确，请重新输入");
            }
        }
    }
}
