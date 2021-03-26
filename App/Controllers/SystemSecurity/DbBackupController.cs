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
        private readonly DbBackupApp dbBackupApp;
        private readonly IWebHostEnvironment webHostEnvironment;

        public DbBackupController(DbBackupApp dbBackupApp, IWebHostEnvironment webHostEnvironment)
        {
            this.dbBackupApp = dbBackupApp;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index(string queryJson)
        {
            var data = dbBackupApp.GetList(queryJson);
            return Success(data);
        }
        [HttpPost]
        public IActionResult Submit(DbBackupEntity dbBackupEntity)
        {
            dbBackupEntity.F_FilePath = "~/Resource/DbBackup/" + dbBackupEntity.F_FileName + ".bak";
            dbBackupEntity.F_FileName = dbBackupEntity.F_FileName + ".bak";
            dbBackupApp.Submit(dbBackupEntity);
            return Success();
        }
        [HttpPost]
        [HandlerAuthorize]
        public IActionResult Delete(string keyValue)
        {
            dbBackupApp.Delete(keyValue);
            return Success();
        }
        [HttpPost]
        [HandlerAuthorize]
        public IActionResult DownloadBackup(string keyValue)
        {
            var data = dbBackupApp.FineOne(keyValue);
            var filepath = Path.Combine(webHostEnvironment.ContentRootPath, data.F_FilePath);
            using var fs = new FileStream(filepath, FileMode.Open);
            return File(fs, "application/octet-stream", data.F_FileName);
        }
    }
}
