using Data.Entity.SystemSecurity;
using Data.IRepository.SystemSecurity;
using Microsoft.AspNetCore.Http;
using Service;
using System.Collections.Generic;
using System.Linq;

namespace AdminApprovalBack.Services.SystemSecurity
{
    public class FilterIPApp : AppService
    {
        private readonly IFilterIPRepository filterIpRepository;

        public FilterIPApp(IFilterIPRepository service, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.filterIpRepository = service;
        }

        public List<FilterIPEntity> GetList(string keyword)
        {
            var query = filterIpRepository.IQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(it => it.F_StartIP.Contains(keyword));
            }
            return query.OrderByDescending(t => t.F_DeleteTime).ToList();
        }
        public FilterIPEntity GetForm(string keyValue)
        {
            return filterIpRepository.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            filterIpRepository.Delete(t => t.F_Id == keyValue);
        }
        public void SubmitForm(FilterIPEntity filterIPEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                ModifyEntity(filterIPEntity, keyValue);
                filterIpRepository.Update(filterIPEntity);
            }
            else
            {
                CreateEntity(filterIPEntity);
                filterIpRepository.Insert(filterIPEntity);
            }
        }
    }
}
