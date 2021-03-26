using Data.Entity.SystemSecurity;
using Data.IRepository.SystemSecurity;
using Microsoft.AspNetCore.Http;
using Service;
using System.Collections.Generic;
using System.Linq;

namespace AdminApprovalBack.Services.SystemSecurity
{
    public class FilterIPApp : AppService<IFilterIPRepository, FilterIPEntity>
    {

        public FilterIPApp(IFilterIPRepository service, IHttpContextAccessor httpContextAccessor)
            : base(service, httpContextAccessor) { }

        public List<FilterIPEntity> GetList(string keyword)
        {
            var query = GetList();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(it => it.F_StartIP.Contains(keyword));
            }
            return query.OrderByDescending(t => t.F_DeleteTime).ToList();
        }
    }
}
