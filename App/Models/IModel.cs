using Common;
using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApprovalBack.Models
{
    public class IModel<TThis, TEntity>
        where TThis : IModel<TThis, TEntity>, new()
        where TEntity : IEntity, new()
    {

        public virtual TEntity ToEntity()
        {
            var props = GetType().GetProperties();
            var entity = new TEntity();
            props.ForEach(prop =>
            {
                var value = prop.GetValue(this);
                var entityProp = typeof(TEntity).GetProperty(prop.Name);
                if (entityProp == null)
                {
                    //throw new Exception($"{prop.Name} not exists in entity!");
                    return;
                }
                if (entityProp.PropertyType != prop.PropertyType)
                {
                    return;
                }
                entityProp.SetValue(entity, value);
            });
            return entity;
        }

        public TThis FromEntity(TEntity entity)
        {
            OnFromEntity(entity);
            return (TThis)this;
        }

        protected virtual void OnFromEntity(TEntity entity)
        {
            var props = GetType().GetProperties();
            props.ForEach(prop =>
            {
                var entityProp = typeof(TEntity).GetProperty(prop.Name);
                if (entityProp == null)
                {
                    //throw new Exception($"{prop.Name} not exists in entity!");
                    return;
                }
                if (entityProp.PropertyType != prop.PropertyType)
                {
                    return;
                }
                var value = entityProp.GetValue(entity);
                prop.SetValue(this, value);
            });
        }
    }

}
