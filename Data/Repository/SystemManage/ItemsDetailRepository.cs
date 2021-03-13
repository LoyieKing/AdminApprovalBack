/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/

using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Data.Entity.SystemManage;
using Data.IRepository.SystemManage;
using Data.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.SystemManage
{
    public class ItemsDetailRepository : RepositoryBase<ItemsDetailEntity>, IItemsDetailRepository
    {
        public ItemsDetailRepository(DbContext dbContext) : base(dbContext)
        {
        }
        
        public List<ItemsDetailEntity> GetItemList(string enCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  d.*
                            FROM    Sys_ItemsDetail d
                                    INNER  JOIN Sys_Items i ON i.F_Id = d.F_ItemId
                            WHERE   1 = 1
                                    AND i.F_EnCode = @enCode
                                    AND d.F_EnabledMark = 1
                                    AND d.F_DeleteMark = 0
                            ORDER BY d.F_SortCode ASC");
            DbParameter[] parameter = 
            {
                 new SqlParameter("@enCode",enCode)
            };
            return this.FindList(strSql.ToString(), parameter);
        }


    }
}
