using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data.RepositoryBase
{
    /// <summary>
    /// 仓储实现
    /// </summary>
    public class RepositoryBase : IRepositoryBase
    {
        private readonly DbContext dbContext;

        public RepositoryBase(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private IDbContextTransaction? dbTransaction;

        public IRepositoryBase BeginTrans()
        {
            dbTransaction = dbContext.Database.BeginTransaction();
            return this;
        }

        public int Commit()
        {
            try
            {
                var returnValue = dbContext.SaveChanges();
                dbTransaction?.Commit();

                return returnValue;
            }
            catch (Exception)
            {
                dbTransaction?.Rollback();

                throw;
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            dbTransaction?.Dispose();
            dbContext.Dispose();
        }

        public int Insert<TEntity>(TEntity entity) where TEntity : class
        {
            dbContext.Entry(entity).State = EntityState.Added;
            return dbTransaction == null ? this.Commit() : 0;
        }

        public int Insert<TEntity>(List<TEntity> entities) where TEntity : class
        {
            foreach (var entity in entities)
            {
                dbContext.Entry(entity).State = EntityState.Added;
            }

            return dbTransaction == null ? Commit() : 0;
        }

        public int Update<TEntity>(TEntity entity) where TEntity : class
        {
            dbContext.Set<TEntity>().Attach(entity);
            PropertyInfo[] props = entity.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                var value = prop.GetValue(entity, null);
                if (value != null)
                {
                    if (value.ToString() == "&nbsp;")
                        dbContext.Entry(entity).Property(prop.Name).CurrentValue = null;
                    dbContext.Entry(entity).Property(prop.Name).IsModified = true;
                }
            }

            return dbTransaction == null ? Commit() : 0;
        }

        public int Delete<TEntity>(TEntity entity) where TEntity : class
        {
            dbContext.Set<TEntity>().Attach(entity);
            dbContext.Entry(entity).State = EntityState.Deleted;
            return dbTransaction == null ? Commit() : 0;
        }

        public int Delete<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            var entities = dbContext.Set<TEntity>().Where(predicate).ToList();
            entities.ForEach(m => dbContext.Entry(m).State = EntityState.Deleted);
            return dbTransaction == null ? Commit() : 0;
        }

        public TEntity FindEntity<TEntity>(object keyValue) where TEntity : class
        {
            return dbContext.Set<TEntity>().Find(keyValue);
        }

        public TEntity? FindEntity<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return dbContext.Set<TEntity>().FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> IQueryable<TEntity>() where TEntity : class
        {
            return dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> IQueryable<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return dbContext.Set<TEntity>().Where(predicate);
        }

        public List<TEntity> FindList<TEntity>(Pagination pagination) where TEntity : class, new()
        {
            return dbContext.Set<TEntity>().AsQueryable().PaginationBy(pagination).ToList();
        }

        public List<TEntity> FindList<TEntity>(Expression<Func<TEntity, bool>> predicate, Pagination pagination)
            where TEntity : class, new()
        {
            return dbContext.Set<TEntity>().Where(predicate).PaginationBy(pagination).ToList();
        }
    }
}