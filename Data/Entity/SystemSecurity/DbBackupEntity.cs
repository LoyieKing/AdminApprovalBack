using System;
using Data.Infrastructure;

namespace Data.Entity.SystemSecurity
{
    public class DbBackupEntity : IEntity
    {
        public string BackupType { get; set; } = null!;
        public string DbName { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public string FileSize { get; set; } = null!;
        public string FilePath { get; set; } = null!;
        public DateTime? BackupTime { get; set; }
        public string Description { get; set; } = null!;
    }
}