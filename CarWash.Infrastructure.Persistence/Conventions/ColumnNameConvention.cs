using System;
using FluentNHibernate;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using Humanizer;

namespace CarWash.Infrastructure.Persistence.Conventions
{
    public class ColumnNameConvention : ForeignKeyConvention,
        IIdConvention,
        IPropertyConvention,
        IVersionConvention
    {
        protected override string GetKeyName(Member property, Type type)
        {
            return property == null
                ? type.Name.Camelize()
                : property.Name.Camelize();
        }

        public void Apply(IIdentityInstance instance)
        {
            instance.Column(@"id");
        }

        public void Apply(IPropertyInstance instance)
        {
            if (instance.Property != null)
            {
                instance.Property.Name.Camelize();
            }
        }

        public void Apply(IVersionInstance instance)
        {
            instance.Column(instance.Name.Camelize());
        }
    }
}