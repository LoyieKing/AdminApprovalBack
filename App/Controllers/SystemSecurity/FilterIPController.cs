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
        public IActionResult GetGridJson(string keyword)
        {
            var data = filterIPApp.GetList(keyword);
            return Success(data);
        }
        [HttpGet]
        public IActionResult GetFormJson(string keyValue)
        {
            var data = filterIPApp.GetForm(keyValue);
            return Success(data);
        }
        [HttpPost]
        public IActionResult SubmitForm(FilterIPEntity filterIPEntity, string keyValue)
        {
            filterIPApp.SubmitForm(filterIPEntity, keyValue);
            return Success();
        }
        [HttpPost]
        [HandlerAuthorize]
        public IActionResult DeleteForm(string keyValue)
        {
            filterIPApp.DeleteForm(keyValue);
            return Success();
        }
    }
}
