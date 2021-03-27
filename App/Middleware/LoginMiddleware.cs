using Data.Entity.SystemManage;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Service.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware
{
    public static class LoginMiddleware
    {

        public static async Task LoginHandler(HttpContext httpContext, Func<Task> next)
        {
            var endpoint = httpContext.GetEndpoint();
            if (endpoint == null)
            {
                //no endpoints match, 404 will be throwed.
                await next();
                return;
            }

            if (httpContext.Request.Path.StartsWithSegments(PathString.FromUriComponent("/api/login")))
            {
                await next();
                return;
            }
            var userinfo = httpContext.GetUserInformation();
            if (userinfo == null)
            {
                httpContext.Items.Add("logininfo", userinfo);
                await next();
                return;
                var resp = JsonConvert.SerializeObject(new { success = false, message = "请先登录" });
                httpContext.Response.StatusCode = 400;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(resp, Encoding.UTF8);
                return;
            }
            else
            {
                httpContext.Items.Add("logininfo", userinfo);
                await next();
                return;
            }
        }

    }

}
