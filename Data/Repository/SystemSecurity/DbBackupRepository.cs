using Common.IO;
using Data.Entity.SystemSecurity;
using Data.IRepository.SystemSecurity;
using Data.RepositoryBase;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace Data.Repository.SystemSecurity
{
    public class DbBackupRepository : RepositoryBase<DbBackupEntity>, IDbBackupRepository
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public DbBackupRepository(DbContext dbContext, IHostingEnvironment hostingEnvironment) : base(dbContext)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public void DeleteForm(string keyValue)
        {
            using var trans = DbContext.Database.BeginTransaction();
            var dbBackupEntity = FindEntity(keyValue);
            if (dbBackupEntity != null)
            {
                hostingEnvironment.DeleteFile(dbBackupEntity.F_FilePath);
                Delete(dbBackupEntity);
            }

            trans.Commit();
        }

        public void ExecuteDbBackup(DbBackupEntity dbBackupEntity)
        {
            dbBackupEntity.F_BackupTime ??= DateTime.Now;
            var filename = dbBackupEntity.F_FileName;
            if (filename == null)
            {
                filename = dbBackupEntity.F_BackupTime!.ToString();
            }
            if (string.IsNullOrEmpty(Path.GetExtension(filename)))
            {
                filename = Path.ChangeExtension(filename, ".bak");
            }
            dbBackupEntity.F_FileName = filename!;
            dbBackupEntity.F_FilePath ??= "~/Resource/DbBackup/" + dbBackupEntity.F_FileName;
            DbContext.Database.ExecuteSqlRaw(
                $"backup database {dbBackupEntity.F_DbName} to disk ='{Path.Combine(hostingEnvironment.ContentRootPath, dbBackupEntity.F_FilePath)}'");
            dbBackupEntity.F_FileSize = FileHelper.ToFileSize(FileHelper.GetFileSize(dbBackupEntity.F_FilePath));
            Insert(dbBackupEntity);
        }
    }
}