using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using Common.Query;
using Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Data.RepositoryBase
{
    public interface IRepository<TEntity> where TEntity : IEntity, new()
    {
        public DbContext DbContext { get; }
        int Insert(TEntity entity);
        int Insert(IEnumerable<TEntity> entities);
        int Update(TEntity entity);
        int Delete(TEntity entity);
        int Delete(Expression<Func<TEntity, bool>> predicate);
        TEntity? FindEntity(int id);
        TEntity? FindEntity(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> IQueryable();
        IQueryable<TEntity> IQueryable(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> FindList(Pagination pagination);
        List<TEntity> FindList(Expression<Func<TEntity, bool>> predicate, Pagination pagination);
    }
}
