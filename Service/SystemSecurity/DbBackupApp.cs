using Data.Entity.SystemSecurity;
using Data.IRepository.SystemSecurity;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdminApprovalBack.Services.SystemSecurity
{
    public class DbBackupApp : AppService
    {
        private readonly IDbBackupRepository dbBackupRepository;

        public DbBackupApp(IDbBackupRepository service, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.dbBackupRepository = service;
        }

        public List<DbBackupEntity> GetList(string queryJson)
        {
            var query = dbBackupRepository.IQueryable();
            var queryParam = JsonConvert.DeserializeObject<QueryJson>(queryJson);
            if (!string.IsNullOrEmpty(queryParam.Keyword) && !string.IsNullOrEmpty(queryParam.Codition))
            {
                string condition = queryParam.Codition;
                string keyword = queryParam.Keyword;
                switch (condition)
                {
                    case "DbName":
                        query = query.Where(it => it.F_DbName.Contains(keyword));
                        break;
                    case "FileName":
                        query = query.Where(it => it.F_FileName.Contains(keyword));
                        break;
                }
            }
            return query.OrderByDescending(t => t.F_BackupTime).ToList();
        }
        public DbBackupEntity GetForm(string keyValue)
        {
            return dbBackupRepository.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            dbBackupRepository.DeleteForm(keyValue);
        }
        public void SubmitForm(DbBackupEntity dbBackupEntity)
        {
            dbBackupEntity.F_Id = Common.Utils.GuId();
            dbBackupEntity.F_EnabledMark = true;
            dbBackupEntity.F_BackupTime = DateTime.Now;
            dbBackupRepository.ExecuteDbBackup(dbBackupEntity);
        }

    }

    class QueryJson
    {
        public string? Codition { get; set; }
        public string? Keyword { get; set; }
        public string? TimeType { get; set; }

    }
}
