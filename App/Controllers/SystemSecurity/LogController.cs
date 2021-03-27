using AdminApprovalBack.Interceptors;
using AdminApprovalBack.Services.SystemSecurity;
using Common.Query;
using Microsoft.AspNetCore.Mvc;

namespace AdminApprovalBack.Controllers.SystemSecurity
{
    [Area("SystemSecurity")]
    public class LogController : ControllerBase
    {
        private readonly LogService logService;

        public LogController(LogService logService)
        {
            this.logService = logService;
        }

        [HttpGet]
        public IActionResult Index(Pagination pagination, string queryJson)
        {
            var data = new
            {
                rows = logService.GetList(pagination, queryJson),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Json(data);
        }
        [HttpPost]
        [HandlerAuthorize]
        public IActionResult RemoveLog(string keepTime)
        {
            logService.RemoveLog(keepTime);
            return Success();
        }
    }
}
