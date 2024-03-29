﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Common.Query;
using Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data.RepositoryBase
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : IEntity, new()
    {
        public DbContext DbContext { get; }

        public Repository(DbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public int Insert(TEntity entity)
        {
            DbContext.Add(entity);
            return DbContext.SaveChanges();
        }

        public int Insert(IEnumerable<TEntity> entities)
        {
            DbContext.Add(entities);
            return DbContext.SaveChanges();
        }

        public int Update(TEntity entity)
        {
            DbContext.Set<TEntity>().Attach(entity);
            PropertyInfo[] props = entity.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if (prop.Name == "Id") continue;
                if (prop.Name == "LazyLoader") continue;
                var value = prop.GetValue(entity, null);
                if (value == null) continue;

                var member = DbContext.Entry(entity).Member(prop.Name);
                member.IsModified = true;
                // if (member is PropertyEntry propertyEntry)
                // {
                //     propertyEntry.IsModified = true;
                // }
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

        public TEntity FindEntity(int id)
        {
            return DbContext.Set<TEntity>().Find(id);
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