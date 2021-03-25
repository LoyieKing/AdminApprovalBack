using Common.Query;
using Data.Entity.SystemSecurity;
using Data.IRepository.SystemSecurity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Middleware;
using Newtonsoft.Json;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdminApprovalBack.Services.SystemSecurity
{
    public class LogApp : AppService
    {
        private ILogRepository service;

        public LogApp(ILogRepository service, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.service = service;
        }

        public List<LogEntity> GetList(Pagination pagination, string queryJson)
        {
            var query = service.IQueryable();
            var queryParam = JsonConvert.DeserializeObject<QueryJson>(queryJson);
            if (!string.IsNullOrEmpty(queryParam.Keyword))
            {
                string keyword = queryParam.Keyword;
                query = query.Where(it => it.F_Account.Contains(keyword));
            }
            if (!string.IsNullOrEmpty(queryParam.TimeType))
            {
                string timeType = queryParam.TimeType;
                DateTime startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                DateTime endTime = startTime.AddDays(1);
                switch (timeType)
                {
                    case "1":
                        break;
                    case "2":
                        startTime = DateTime.Now.AddDays(-7);
                        break;
                    case "3":
                        startTime = DateTime.Now.AddMonths(-1);
                        break;
                    case "4":
                        startTime = DateTime.Now.AddMonths(-3);
                        break;
                    default:
                        break;
                }
                query = query.Where(it => it.F_Date >= startTime && it.F_Date <= endTime);
            }
            return query.PaginationBy(pagination).ToList();
        }
        public void RemoveLog(string keepTime)
        {
            DateTime operateTime = DateTime.Now;
            if (keepTime == "7")            //保留近一周
            {
                operateTime = DateTime.Now.AddDays(-7);
            }
            else if (keepTime == "1")       //保留近一个月
            {
                operateTime = DateTime.Now.AddMonths(-1);
            }
            else if (keepTime == "3")       //保留近三个月
            {
                operateTime = DateTime.Now.AddMonths(-3);
            }
            service.Delete(it => it.F_Date <= operateTime);
        }
        public void WriteDbLog(bool result, string resultLog)
        {
            var userinfo = httpContextAccessor.HttpContext.GetUserInformation();
            LogEntity logEntity = new LogEntity();
            logEntity.F_Date = DateTime.Now;
            logEntity.F_Account = userinfo?.Code ?? "";
            logEntity.F_NickName = userinfo?.Name ?? "";
            logEntity.F_IPAddress = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            logEntity.F_Result = result;
            logEntity.F_Description = resultLog;
            CreateEntity(logEntity);
            service.Insert(logEntity);
        }
        public void WriteDbLog(LogEntity logEntity)
        {
            logEntity.F_Date = DateTime.Now;
            logEntity.F_IPAddress = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            CreateEntity(logEntity);
            service.Insert(logEntity);
        }
    }
}
