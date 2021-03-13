using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using Common.Query;

namespace Data.RepositoryBase
{
    public interface IRepositoryBase<TEntity> where TEntity : class,new()
    {
        int Insert(TEntity entity);
        int Insert(List<TEntity> entities);
        int Update(TEntity entity);
        int Delete(TEntity entity);
        int Delete(Expression<Func<TEntity, bool>> predicate);
        TEntity FindEntity(object keyValue);
        TEntity? FindEntity(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> IQueryable();
        IQueryable<TEntity> IQueryable(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> FindList(Pagination pagination);
        List<TEntity> FindList(Expression<Func<TEntity, bool>> predicate, Pagination pagination);
    }
}
