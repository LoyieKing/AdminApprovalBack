using AdminApprovalBack.Interceptors;
using AdminApprovalBack.Services.SystemSecurity;
using Common.IO;
using Data.Entity.SystemSecurity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace AdminApprovalBack.Controllers.SystemSecurity
{
    [Area("SystemSecurity")]
    public class DbBackupController : ControllerBase
    {
        private readonly DbBackupService dbBackupService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public DbBackupController(DbBackupService dbBackupApp, IWebHostEnvironment webHostEnvironment)
        {
            this.dbBackupService = dbBackupApp;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index(string queryJson)
        {
            var data = dbBackupService.GetList(queryJson);
            return Success(data);
        }
        [HttpPost]
        public IActionResult Backup(string backupType, string? desc = null, string? filename = null)
        {
            dbBackupService.ExecuteDbBackup("graduation", backupType, desc, filename);
            return Success();
        }
        [HttpPost]
        [HandlerAuthorize]
        public IActionResult Delete(int id)
        {
            dbBackupService.Delete(id);
            return Success();
        }
        [HttpPost]
        [HandlerAuthorize]
        public IActionResult DownloadBackup(int id)
        {
            var data = dbBackupService.FindOne(id);
            var filepath = Path.Combine(webHostEnvironment.ContentRootPath, data.FilePath);
            using var fs = new FileStream(filepath, FileMode.Open);
            return File(fs, "application/octet-stream", data.FileName);
        }
    }
}
