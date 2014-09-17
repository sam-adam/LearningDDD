using FluentNHibernate.Mapping;
using System;

namespace CarWash.Infrastructure.Persistence
{
    using Domain;

    public class MoneyMap
    {
        public static Action<ComponentPart<Money>> Mapping()
        {
            return m =>
            {
                m.Map(x => x.Value);
                m.Map(x => x.CurrencyCode);
            };
        }
    }
}