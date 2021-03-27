using Data.Entity.SystemManage;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware
{
    public static class LoginMiddleware
    {
        private static readonly string secret = "wAngy1lei0Nradu2a4!clkSLKasdlzkc";
        private static readonly byte[] secretBytes = Encoding.ASCII.GetBytes(secret);
        private static readonly JwtEncoder jwtEncoder = new JwtEncoder(new HMACSHA256Algorithm(), new JsonNetSerializer(), new JwtBase64UrlEncoder());
        private static readonly JwtDecoder jwtDecoder = new JwtDecoder(new JsonNetSerializer(), new JwtBase64UrlEncoder());

        public static async Task LoginHandler(HttpContext httpContext, Func<Task> next)
        {
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

        public static void SetUserInformation(this HttpContext httpContext, UserEntity userEntity)
        {
            var information = new UserInformation
            {
                Id = userEntity.F_Id,
                Code = userEntity.F_Account,
                Name = userEntity.F_RealName,
                CompanyId = userEntity.F_OrganizeId,
                DepartmentId = userEntity.F_DepartmentId,
                RoleId = userEntity.F_RoleId,
                LoginTime = DateTime.Now
            };
            httpContext.Response.Cookies.Append("Authorization", "Bear " + jwtEncoder.Encode(information, secretBytes));
        }
    }

    public class UserInformation
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string Id { get; set; } = null!;
        /// <summary>
        /// 用户账户名
        /// </summary>
        public string Code { get; set; } = null!;
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string Name { get; set; } = null!;
        public string CompanyId { get; set; } = null!;
        public string DepartmentId { get; set; } = null!;
        public string RoleId { get; set; } = null!;
        public DateTime LoginTime { get; set; }

        [JsonIgnore]
        public bool IsAdmin { get => Code == "admin"; }
    }
}
