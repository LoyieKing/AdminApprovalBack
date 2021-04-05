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
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(it => it.UserName.Contains(keyword) || it.RealName.Contains(keyword) || it.Contract.Contains(keyword));
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

        public string HashPassword(string pwd)
        {
            return Md5.Hash(DesEncrypt.Encrypt(pwd).ToLower(), 32).ToLower();
        }

        public UserEntity CheckPassword(string username, string password)
        {
            UserEntity userEntity = service.IQueryable().Where(t => t.UserName == username).FirstOrDefault();
            if (userEntity == null)
            {
                throw new Exception("账户不存在，请重新输入");
            }
            if (userEntity.EnabledMark == false)
            {
                throw new Exception("账户被系统锁定,请联系管理员");
            }



            password = HashPassword(password);
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

            oldpwd = HashPassword(oldpwd);
            if (oldpwd != userEntity.Password)
            {
                throw new Exception("密码不正确，请重新输入");
            }
            userEntity.Password = HashPassword(newpwd);
            service.Update(userEntity);
        }

        public bool IsHigherLevel(int userId, int higherUserId)
        {
            var user = service.FindOne(userId);
            var higher = service.FindOne(higherUserId);
            var orgs = new Queue<OrganizeEntity>();
            higher.Organizes.ForEach(org => org.Organize.SubOrganizes.ForEach(suborg => orgs.Enqueue(suborg)));
            while (orgs.Count != 0)
            {
                var org = orgs.Dequeue();
                if (user.Organizes.Any(userorg => userorg.Id == org.Id)) return true;
                org.SubOrganizes.ForEach(suborg => orgs.Enqueue(org));
            }
            return false;
        }
    }
}
