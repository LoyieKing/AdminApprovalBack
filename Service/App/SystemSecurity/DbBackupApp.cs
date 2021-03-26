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
    public class DbBackupApp : AppService<IDbBackupRepository, DbBackupEntity>
    {

        public DbBackupApp(IDbBackupRepository service, IHttpContextAccessor httpContextAccessor)
            : base(service, httpContextAccessor) { }

        public List<DbBackupEntity> GetList(string queryJson)
        {
            var query = GetList();
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

        public void SubmitForm(DbBackupEntity dbBackupEntity)
        {
            dbBackupEntity.F_Id = Common.Utils.GuId();
            dbBackupEntity.F_EnabledMark = true;
            dbBackupEntity.F_BackupTime = DateTime.Now;
            repo.ExecuteDbBackup(dbBackupEntity);
        }

    }

    class QueryJson
    {
        public string? Codition { get; set; }
        public string? Keyword { get; set; }
        public string? TimeType { get; set; }

    }
}
