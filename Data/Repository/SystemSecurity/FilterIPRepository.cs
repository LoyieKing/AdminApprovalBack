
using Data.Entity.SystemSecurity;
using Data.IRepository.SystemSecurity;
using Data.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.SystemSecurity
{
    public class FilterIPRepository : RepositoryBase<FilterIPEntity>, IFilterIPRepository
    {
        public FilterIPRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
