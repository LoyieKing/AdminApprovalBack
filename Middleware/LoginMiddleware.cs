using JWT;
using JWT.Serializers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware
{
    public static class LoginMiddleware
    {
        private static readonly JwtDecoder jwtDecoder = new JwtDecoder(new JsonNetSerializer(), new JwtBase64UrlEncoder());

        public static async Task LoginHandler(HttpContext httpContext, Func<Task> next)
        {
            if (httpContext.Request.PathBase.StartsWithSegments(PathString.FromUriComponent("/api/login")))
            {
                await next();
                return;
            }
            httpContext.Items.Add("logininfo", httpContext.GetUserInformation());
        }

        public static UserInformation? GetUserInformation(this HttpContext context)
        {
            if (context.Items.TryGetValue("logininfo", out var tmp))
            {
                return tmp as UserInformation;
            }
            if (!context.Request.Headers.TryGetValue("Authorization", out var value))
            {
                return null;
            }
            var token = value.Where(it => it.StartsWith("Bear ")).FirstOrDefault();
            if (token == null) return null;
            try
            {
                var payload = jwtDecoder.DecodeToObject<UserInformation>(token.Substring("Bear ".Length));
                return payload;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    public class UserInformation
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }

        public bool IsAdmin { get; set; }
    }
}
