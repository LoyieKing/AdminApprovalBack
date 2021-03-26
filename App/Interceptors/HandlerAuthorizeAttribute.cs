using AdminApprovalBack.Services.SystemManage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Middleware;

namespace AdminApprovalBack.Interceptors
{
    internal class InternalHandlerAuthorize : ActionFilterAttribute
    {
        private readonly RoleAuthorizeApp roleAuthorizeApp;

        public bool Ignore { get; set; }
        public InternalHandlerAuthorize(RoleAuthorizeApp roleAuthorizeApp,bool ignore)
        {
            this.Ignore = ignore;
            this.roleAuthorizeApp = roleAuthorizeApp;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userInfo = filterContext.HttpContext.GetUserInformation();
            if (userInfo == null)
            {
                filterContext.Result = new JsonResult(new { success = false, message = "您尚未登录，权限不足！" });
                return;
            }
            if (userInfo.IsAdmin)
            {
                return;
            }
            if (Ignore == false)
            {
                return;
            }
            if (!this.ActionAuthorize(filterContext, userInfo))
            {
                StringBuilder sbScript = new StringBuilder();
                sbScript.Append("<script type='text/javascript'>alert('您的权限不足，访问被拒绝！');</script>");
                filterContext.Result = new ContentResult() { Content = sbScript.ToString() };
                return;
            }
        }
        private bool ActionAuthorize(ActionExecutingContext filterContext, UserInformation userInfo)
        {
            var roleId = userInfo.RoleId;
            var action = filterContext.ActionDescriptor.DisplayName;
            return roleAuthorizeApp.ActionValidate(roleId, "", action);
        }
    }

    public class HandlerAuthorizeAttribute : TypeFilterAttribute
    {
        public HandlerAuthorizeAttribute(bool ignore = false) : base(typeof(InternalHandlerAuthorize))
        {
            this.Arguments = new object[] { ignore };
        }
    }
}
