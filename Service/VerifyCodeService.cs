using Common;
using Common.Encrypt;
using Hei.Captcha;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Exceptions;
using JWT.Serializers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApprovalBack.Services
{
    public class VerifyCodeService
    {
        public enum State
        {
            OK,
            WrongCode,
            Expired,
            Invalid
        }

        readonly SecurityCodeHelper securityCodeHelper = new SecurityCodeHelper();
        readonly UtcDateTimeProvider timeProvider = new UtcDateTimeProvider();
        const string secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";
        readonly byte[] secretBytes = Encoding.ASCII.GetBytes(secret);
        readonly JwtEncoder jwtEncoder;
        readonly JwtDecoder jwtDecoder;

        public VerifyCodeService()
        {
            var algorithm = new HMACSHA256Algorithm(); // symmetric
            var serializer = new JsonNetSerializer();
            var urlEncoder = new JwtBase64UrlEncoder();
            var validator = new JwtValidator(serializer, timeProvider);
            jwtEncoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            jwtDecoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);
        }

        public (string token, byte[] image) GenerateCode()
        {
            var code = Utils.RndEnNum(4);
            var image = securityCodeHelper.GetEnDigitalCodeByte(code);
            var token = jwtEncoder.Encode(new Payload { Code = DesEncrypt.Encrypt(code, secret), ExpiredAt = (long)UnixEpoch.GetSecondsSince(timeProvider.GetNow().AddMinutes(10)) }, secretBytes);
            return (token, image);
        }

        public State VerifyCode(string token, string myCode)
        {
            try
            {
                var now = (long)UnixEpoch.GetSecondsSince(timeProvider.GetNow());
                var payload = jwtDecoder.DecodeToObject<Payload>(token, secretBytes, true);
                var realCode = DesEncrypt.Decrypt(payload.Code, secret);
                if (realCode.ToUpper() == myCode.ToUpper())
                {
                    return State.OK;
                }
                else
                {
                    return State.WrongCode;
                }
            }
            catch (SignatureVerificationException e)
            {
                if (e.Message == "Token has expired.") return State.Expired;
                return State.Invalid;
            }
            catch (Exception e)
            {
                return State.Invalid;
            }

        }


        class Payload
        {
            [JsonProperty("code")]
            public string Code { get; set; }

            [JsonProperty("exp")]
            public long ExpiredAt { get; set; }
        }
    }
}
