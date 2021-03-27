using Common.IO;
using Data.Entity.SystemSecurity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdminApprovalBack.Services.SystemSecurity
{
    public class DbBackupService
    {
        private readonly RepoService<DbBackupEntity> repoService;
        private readonly IHostingEnvironment hostingEnvironment;

        public DbBackupService(RepoService<DbBackupEntity> repoService, IHostingEnvironment hostingEnvironment)
        {
            this.repoService = repoService;
            this.hostingEnvironment = hostingEnvironment;
        }

        public List<DbBackupEntity> GetList(string queryJson)
        {
            var query = repoService.IQueryable();
            if (queryJson != null)
            {
                var queryParam = JsonConvert.DeserializeObject<QueryJson>(queryJson);
                if (!string.IsNullOrEmpty(queryParam.Keyword) && !string.IsNullOrEmpty(queryParam.Codition))
                {
                    string condition = queryParam.Codition;
                    string keyword = queryParam.Keyword;
                    switch (condition)
                    {
                        case "DbName":
                            query = query.Where(it => it.DbName.Contains(keyword));
                            break;
                        case "FileName":
                            query = query.Where(it => it.FileName.Contains(keyword));
                            break;
                    }
                }
            }
            return query.OrderByDescending(t => t.BackupTime).ToList();
        }

        public void Delete(int id)
        {
            using var trans = repoService.DbContext.Database.BeginTransaction();
            var dbBackupEntity = repoService.FindOne(id);
            if (dbBackupEntity != null)
            {
                hostingEnvironment.DeleteFile(dbBackupEntity.FilePath);
                repoService.Delete(dbBackupEntity);
            }

            trans.Commit();
        }

        public DbBackupEntity FindOne(int id)
        {
            return repoService.FindOne(id);
        }

        public void ExecuteDbBackup(string dbName, string backupType, string desc = null, string filename = null)
        {
            using var trans = repoService.DbContext.Database.BeginTransaction();

            DbBackupEntity dbBackupEntity = new DbBackupEntity
            {
                BackupTime = DateTime.Now,
                DbName = dbName,
                BackupType = backupType,
                Description = desc
            };
            if (filename == null)
            {
                filename = dbBackupEntity.BackupTime!.ToString();
            }
            if (string.IsNullOrEmpty(Path.GetExtension(filename)))
            {
                filename = Path.ChangeExtension(filename, ".bak");
            }
            dbBackupEntity.FileName = filename;
            dbBackupEntity.FilePath ??= "~/Resource/DbBackup/" + dbBackupEntity.FileName;
            repoService.DbContext.Database.ExecuteSqlRaw(
                            $"backup database {dbName} to disk ='{Path.Combine(hostingEnvironment.ContentRootPath, dbBackupEntity.FilePath)}'");
            dbBackupEntity.FileSize = FileHelper.ToFileSize(FileHelper.GetFileSize(dbBackupEntity.FilePath));
            repoService.Update(dbBackupEntity);
            trans.Commit();
        }
    }

    class QueryJson
    {
        public string? Codition { get; set; }
        public string? Keyword { get; set; }
        public string? TimeType { get; set; }

    }
}
