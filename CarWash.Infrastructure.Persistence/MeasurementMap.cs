using FluentNHibernate.Mapping;
using System;

namespace CarWash.Infrastructure.Persistence
{
    using Domain;

    public class MeasurementMap
    {
        public static Action<ComponentPart<Measurement>> Mapping()
        {
            return m =>
            {
                m.Map(x => x.Value);
                m.Map(x => x.Code);
            };
        } 
    }
}