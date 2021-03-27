using Data.Entity.SystemManage;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Login
{
    public static class LoginExtension
    {
        private static readonly string secret = "wAngy1lei0Nradu2a4!clkSLKasdlzkc";
        private static readonly byte[] secretBytes = Encoding.ASCII.GetBytes(secret);
        private static readonly JwtEncoder jwtEncoder = new JwtEncoder(new HMACSHA256Algorithm(), new JsonNetSerializer(), new JwtBase64UrlEncoder());
        private static readonly JwtDecoder jwtDecoder = new JwtDecoder(new JsonNetSerializer(), new JwtBase64UrlEncoder());

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
                Id = userEntity.Id,
                UserName = userEntity.UsernName,
                LoginTime = DateTime.Now
            };
            httpContext.Response.Cookies.Append("Authorization", "Bear " + jwtEncoder.Encode(information, secretBytes));
        }
    }
}
