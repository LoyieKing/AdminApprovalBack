using Data.Entity.SystemManage;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
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

        private static JsonSerializerSettings ssonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
        private static JsonNetSerializer jsonNetSerializer = new JsonNetSerializer(JsonSerializer.Create(ssonSerializerSettings));

        private static readonly JwtEncoder jwtEncoder = new JwtEncoder(new HMACSHA256Algorithm(), jsonNetSerializer, new JwtBase64UrlEncoder());
        private static readonly JwtDecoder jwtDecoder = new JwtDecoder(jsonNetSerializer, new JwtBase64UrlEncoder());

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

        public static string CreateJwtToken(UserEntity userEntity)
        {
            var information = new UserInformation
            {
                Id = userEntity.Id,
                UserName = userEntity.UserName,
                LoginTime = DateTime.Now
            };
            return jwtEncoder.Encode(information, secretBytes);
        }
    }
}
