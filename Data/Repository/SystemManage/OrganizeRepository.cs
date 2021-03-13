/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/

using Data.Entity.SystemManage;
using Data.IRepository.SystemManage;
using Data.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.SystemManage
{
    public class OrganizeRepository : RepositoryBase<OrganizeEntity>, IOrganizeRepository
    {
        public OrganizeRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
