using AdminApprovalBack.Interceptors;
using AdminApprovalBack.Services.SystemSecurity;
using Data.Entity.SystemSecurity;
using Microsoft.AspNetCore.Mvc;

namespace AdminApprovalBack.Controllers.SystemSecurity
{
    [Area("SystemSecurity")]
    public class FilterIPController : ControllerBase
    {
        private readonly FilterIPApp filterIPApp;

        public FilterIPController(FilterIPApp filterIPApp)
        {
            this.filterIPApp = filterIPApp;
        }

        [HttpGet]
        public IActionResult Index(string keyword)
        {
            var data = filterIPApp.GetList(keyword);
            return Success(data);
        }
        [HttpGet]
        public IActionResult One(string keyValue)
        {
            var data = filterIPApp.FineOne(keyValue);
            return Success(data);
        }
        [HttpPost]
        public IActionResult Submit(FilterIPEntity filterIPEntity, string keyValue)
        {
            filterIPApp.Submit(filterIPEntity, keyValue);
            return Success();
        }
        [HttpPost]
        [HandlerAuthorize]
        public IActionResult Delete(string keyValue)
        {
            filterIPApp.Delete(keyValue);
            return Success();
        }
    }
}
