using Common.IO;
using Data.Entity.SystemSecurity;
using Data.IRepository.SystemSecurity;
using Data.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

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
            DbContext.Database.ExecuteSqlRaw(
                $"backup database {dbBackupEntity.F_DbName} to disk ='{dbBackupEntity.F_FilePath}'");
            dbBackupEntity.F_FileSize = FileHelper.ToFileSize(FileHelper.GetFileSize(dbBackupEntity.F_FilePath));
            dbBackupEntity.F_FilePath = "/Resource/DbBackup/" + dbBackupEntity.F_FileName;
            Insert(dbBackupEntity);
        }
    }
}