using System;
using Data.Infrastructure;

namespace Data.Entity.SystemSecurity
{
    public class DbBackupEntity : IEntity<DbBackupEntity>
    {
        public string F_BackupType { get; set; }
        public string F_DbName { get; set; }
        public string F_FileName { get; set; }
        public string F_FileSize { get; set; }
        public string F_FilePath { get; set; }
        public DateTime? F_BackupTime { get; set; }
        public int? F_SortCode { get; set; }
        public bool? F_EnabledMark { get; set; }
        public string F_Description { get; set; }
    }
}