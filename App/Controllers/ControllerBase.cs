using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApprovalBack.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected virtual IActionResult Success()
        {
            return Json(new { success = true });
        }
        protected virtual IActionResult Success(object? data)
        {
            if (data == null) return Success();
            return Json(new { success = true, data });
        }
        protected virtual IActionResult Error(string message)
        {
            return Json(new { success = false, message });
        }
    }
}
