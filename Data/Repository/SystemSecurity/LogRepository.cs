/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/

using Data.Entity.SystemSecurity;
using Data.IRepository.SystemSecurity;
using Data.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.SystemSecurity
{
    public class LogRepository : RepositoryBase<LogEntity>, ILogRepository
    {
        public LogRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
