
using Data.Entity.SystemSecurity;
using Data.RepositoryBase;

namespace Data.IRepository.SystemSecurity
{
    public interface IDbBackupRepository : IRepositoryBase<DbBackupEntity>
    {
        void Delete(string keyValue);
        void ExecuteDbBackup(DbBackupEntity dbBackupEntity);
    }
}
