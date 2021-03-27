using Common.Query;
using Data.Entity.SystemSecurity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Service;
using Service.Login;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdminApprovalBack.Services.SystemSecurity
{
    public class LogService
    {
        private readonly RepoService<LogEntity> repoService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public LogService(RepoService<LogEntity> repoService,IHttpContextAccessor httpContextAccessor)
        {
            this.repoService = repoService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public List<LogEntity> GetList(Pagination pagination, string queryJson)
        {
            var query = repoService.IQueryable();
            if (queryJson != null)
            {
                var queryParam = JsonConvert.DeserializeObject<QueryJson>(queryJson);
                if (!string.IsNullOrEmpty(queryParam.Keyword))
                {
                    string keyword = queryParam.Keyword;
                    query = query.Where(it => it.UserName.Contains(keyword));
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
                    query = query.Where(it => it.Date >= startTime && it.Date <= endTime);
                }
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
            repoService.Delete(it => it.Date <= operateTime);
        }
        public void WriteDbLog(string type, bool result, string desc)
        {
            var userinfo = httpContextAccessor.HttpContext.GetUserInformation();
            LogEntity logEntity = new LogEntity();
            logEntity.Type = type;
            logEntity.Date = DateTime.Now;
            logEntity.UserName = userinfo?.UserName ?? "";
            logEntity.IPAddress = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            logEntity.Result = result;
            logEntity.Description = desc;
            repoService.Update(logEntity);
        }
    }
}
