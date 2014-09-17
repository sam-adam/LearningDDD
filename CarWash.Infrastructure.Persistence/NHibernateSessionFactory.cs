using System;
using System.Collections.Generic;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Utils;
using NHibernate;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;

namespace CarWash.Infrastructure.Persistence
{
    using Conventions;

    public class NHibernateSessionFactory
    {
        private readonly Boolean _updateSchema;
        private readonly Connection _connection;
        private readonly IList<Assembly> _mappingAssemblies;

        private Boolean _isInitialized;
        private ISessionFactory _sessionFactory;

        public NHibernateSessionFactory(Connection connection, IList<Assembly> mappingAssemblies, Boolean updateSchema = false)
        {
            _connection = connection;
            _updateSchema = updateSchema;
            _mappingAssemblies = mappingAssemblies;
            _isInitialized = false;
        }

        public Connection Connection
        {
            get { return _connection; }
        }

        public ISession Session
        {
            get
            {
                if (!_isInitialized)
                {
                    throw new Exception(@"SessionFactory is not initialized");
                }

                return _sessionFactory.GetCurrentSession() ?? _sessionFactory.OpenSession();
            }
        }

        /// <summary>
        /// Get SessionFactory's current stateless session if available,
        /// otherwise open another one
        /// </summary>
        public IStatelessSession StatelessSession
        {
            get
            {
                if (!_isInitialized)
                {
                    throw new Exception(@"SessionFactory is not initialized");
                }

                return _sessionFactory.OpenStatelessSession();
            }
        }

        /// <summary>
        /// True if the Initiliaze() method has been called, otherwise false
        /// </summary>
        public Boolean IsInitialized
        {
            get { return _isInitialized; }
        }

        /// <summary>
        /// Initialize the SessionFactory
        /// </summary>
        public void Initialize()
        {
            var connectionString = String.Format(@"SERVER={0};DATABASE={1};USER ID={2};PASSWORD={3}", 
                _connection.Host,
                _connection.Database,
                _connection.Username,
                _connection.Password
            );

            _sessionFactory = Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(connectionString))
                .CurrentSessionContext<ThreadLocalSessionContext>()
                .Mappings(map =>
                {
                    map.FluentMappings.Conventions.Add(new ColumnNameConvention());
                    map.FluentMappings.Conventions.Add(new ReferenceConvention());
                    map.FluentMappings.Conventions.Add(new TableNameConvention());
                    
                    _mappingAssemblies.Each(assembly => map.FluentMappings.AddFromAssembly(assembly));
                })
                .ExposeConfiguration(conf =>
                {
                    if (_updateSchema)
                    {
                        new SchemaUpdate(conf).Execute(false, true);
                    }
                })
                .BuildSessionFactory();

            _isInitialized = true;
        }
    }
}