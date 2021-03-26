using AdminApprovalBack.Interceptors;
using AdminApprovalBack.Services.SystemSecurity;
using Common.Query;
using Microsoft.AspNetCore.Mvc;

namespace AdminApprovalBack.Controllers.SystemSecurity
{
    [Area("SystemSecurity")]
    public class LogController : ControllerBase
    {
        private readonly LogApp logApp;

        public LogController(LogApp logApp)
        {
            this.logApp = logApp;
        }

        [HttpGet]
        public IActionResult GetGridJson(Pagination pagination, string queryJson)
        {
            var data = new
            {
                rows = logApp.GetList(pagination, queryJson),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Json(data);
        }
        [HttpPost]
        [HandlerAuthorize]
        public IActionResult SubmitRemoveLog(string keepTime)
        {
            logApp.RemoveLog(keepTime);
            return Success();
        }
    }
}
