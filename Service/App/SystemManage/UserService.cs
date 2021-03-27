using Common.Encrypt;
using Common.Query;
using Data.Entity.SystemManage;
using Data.RepositoryBase;
using Microsoft.AspNetCore.Http;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdminApprovalBack.Services.SystemManage
{
    public class UserService 
    {
        private readonly RepoService<UserEntity> service;

        public UserService(RepoService<UserEntity> service)
        {
            this.service = service;
        }

        public IQueryable<UserEntity> GetList(Pagination pagination, string keyword)
        {
            var query = service.IQueryable();
            query = query.Where(it => it.UsernName != "admin");
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(it => it.UsernName.Contains(keyword) || it.RealName.Contains(keyword) || it.Contract.Contains(keyword));
            }
            return query.PaginationBy(pagination);
        }
        public void Update(UserEntity userEntity)
        {
            service.Update(userEntity);
        }

        public UserEntity FindOne(int id)
        {
            return service.FindOne(id);
        }

        public void Delete(int id)
        {
            service.Delete(id);
        }

        public UserEntity CheckPassword(string username, string password)
        {
            UserEntity userEntity = service.IQueryable().Where(t => t.UsernName == username).FirstOrDefault();
            if (userEntity == null)
            {
                throw new Exception("账户不存在，请重新输入");
            }
            if (userEntity.EnabledMark == false)
            {
                throw new Exception("账户被系统锁定,请联系管理员");
            }



            password = Md5.Hash(DesEncrypt.Encrypt(password).ToLower(), 32).ToLower();
            if (password != userEntity.Password)
            {
                throw new Exception("密码不正确，请重新输入");
            }

            return userEntity;
        }

        public void RevisePassword(int id, string oldpwd, string newpwd)
        {
            UserEntity userEntity = service.FindOne(id);
            if (userEntity == null)
            {
                throw new Exception("账户不存在，请重新输入");
            }

            oldpwd = Md5.Hash(DesEncrypt.Encrypt(oldpwd).ToLower(), 32).ToLower();
            if (oldpwd != userEntity.Password)
            {
                throw new Exception("密码不正确，请重新输入");
            }
            userEntity.Password = Md5.Hash(DesEncrypt.Encrypt(newpwd).ToLower(), 32).ToLower();
            service.Update(userEntity);
        }
    }
}
