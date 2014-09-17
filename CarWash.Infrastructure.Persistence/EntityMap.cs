using System;
using CarWash.Domain;
using FluentNHibernate.Mapping;

namespace CarWash.Infrastructure.Persistence
{
    public abstract class EntityMap<TEntity, TId> : ClassMap<TEntity> where TEntity : Entity<TId>
    {
        protected EntityMap()
        {
            Not.LazyLoad();

            if (typeof (TId) == typeof (Guid))
            {
                Id(x => x.Id)
                    .GeneratedBy.GuidComb();
            }
            else if (typeof (TId) == typeof (int))
            {
                Id(x => x.Id)
                    .GeneratedBy.Increment();
            }

            Map(x => x.CreatedOn);
            Version(x => x.UpdatedOn);
        }
    }
}