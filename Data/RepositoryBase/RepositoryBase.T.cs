using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace Data.RepositoryBase
{
    /// <summary>
    /// 仓储实现
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, new()
    {
        public readonly DbContext DbContext;

        public RepositoryBase(DbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public int Insert(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Added;
            return DbContext.SaveChanges();
        }

        public int Insert(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                DbContext.Entry(entity).State = EntityState.Added;
            }
            return DbContext.SaveChanges();
        }

        public int Update(TEntity entity)
        {
            DbContext.Set<TEntity>().Attach(entity);
            PropertyInfo[] props = entity.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                var value = prop.GetValue(entity, null);
                if (value == null) continue;
                if (value.ToString() == "&nbsp;")
                    DbContext.Entry(entity).Property(prop.Name).CurrentValue = null;
                DbContext.Entry(entity).Property(prop.Name).IsModified = true;
            }

            return DbContext.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Entry(entity).State = EntityState.Deleted;
            return DbContext.SaveChanges();
        }

        public int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = DbContext.Set<TEntity>().Where(predicate).ToList();
            entities.ForEach(m => DbContext.Entry(m).State = EntityState.Deleted);
            return DbContext.SaveChanges();
        }

        public TEntity FindEntity(object keyValue)
        {
            return DbContext.Set<TEntity>().Find(keyValue);
        }

        public TEntity? FindEntity(Expression<Func<TEntity, bool>> predicate)
        {
            return DbContext.Set<TEntity>().FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> IQueryable()
        {
            return DbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> IQueryable(Expression<Func<TEntity, bool>> predicate)
        {
            return DbContext.Set<TEntity>().Where(predicate);
        }

        public List<TEntity> FindList(Pagination pagination)
        {
            return DbContext.Set<TEntity>().AsQueryable().PaginationBy(pagination).ToList();
        }

        public List<TEntity> FindList(Expression<Func<TEntity, bool>> predicate, Pagination pagination)
        {
            return DbContext.Set<TEntity>().Where(predicate).PaginationBy(pagination).ToList();
        }
    }
}