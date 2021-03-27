using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Service.Login;

namespace AdminApprovalBack.Interceptors
{
    public class HandlerAuthorizeAttribute : ActionFilterAttribute
    {
        public HandlerAuthorizeAttribute()
        {
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
            filterContext.Result = new JsonResult(new { success = false, message = "您的权限不足，访问被拒绝！" });
            return;
        }
    }
}
