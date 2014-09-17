using System.Collections.Generic;
using System.Reflection;
using Autofac;
using NHibernate;

namespace CarWash.Infrastructure.Persistence
{
    public class InfrastructurePersistenceModule : Module
    {
        public InfrastructurePersistenceModule(Connection connection, IList<Assembly> mappingAssemblies)
        {
            NHibernateSessionManager.AddSessionFactory(new NHibernateSessionFactory(connection, mappingAssemblies));
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.Register(x => NHibernateSessionManager.SessionFactory)
                .AsSelf()
                .SingleInstance();
            builder.Register(x => NHibernateSessionManager.SessionFactory.Session)
                .As<ISession>();
        }
    }
}