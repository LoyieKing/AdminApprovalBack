﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Service.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdminApprovalBack.Controllers
{

    public abstract class ControllerBase : Controller
    {
        private static JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };


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

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var error = context.Exception;
            if (error != null)
            {
                context.Result = Error(error.Message);
                context.ExceptionHandled = true;
            }
        }

        public override JsonResult Json(object data)
        {
            return base.Json(data, jsonSerializerOptions);
        }

        protected virtual UserInformation GetUserInformation()
        {
            var user = HttpContext.GetUserInformation();
            if (user == null)
            {
                throw new Exception("尚未登录!");
            }
            return user;
        }

        protected virtual string throwStringAssert(string message)
        {
            throw new Exception(message);
        }
    }
}
