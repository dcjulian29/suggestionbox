using Common.Logging;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Configuration;
using System.Runtime.Caching;
using Configuration = NHibernate.Cfg.Configuration;

namespace SuggestionBox.Data
{
    /// <summary>
    ///     Provides Session Managers for the various databases that this applications uses.
    /// </summary>
    public class Database
    {
        private static readonly string _cacheKey = "Database-SuggestionBox";
        private static readonly object _cacheLock = new object();

        private static readonly CacheItemPolicy _cachePolicy = new CacheItemPolicy()
        {
            AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddDays(1))
        };

        private static readonly ILog _log = LogManager.GetLogger<Database>();
        private static readonly ObjectCache _sessionFactories = MemoryCache.Default;

        static Database() => UnitTests = false;

        /// <summary>
        ///     Gets the session manager for the SuggestionBox database.
        /// </summary>
        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactories.Contains(_cacheKey))
                {
                    _log.Debug(m => m("Returning existing database session"));

                    return _sessionFactories[_cacheKey] as ISessionFactory;
                }

                lock (_cacheLock)
                {
                    if (_sessionFactories.Contains(_cacheKey))
                    {
                        _log.Debug(m => m("Returning existing database session."));

                        return _sessionFactories[_cacheKey] as ISessionFactory;
                    }

                    _log.Debug(m => m("Creating a new database session."));

                    var sessionFactory = Fluently.Configure()
                        .Database(DatabaseConfigurer)
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Database>())
                        .ExposeConfiguration(BuildSchema)
                        .BuildSessionFactory();

                    _sessionFactories.Set(_cacheKey, sessionFactory, _cachePolicy);

                    return sessionFactory;
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether Unit Test are being run.
        /// </summary>
        public static bool UnitTests { get; set; }

        private static void BuildSchema(Configuration config) =>
                    new SchemaExport(config).Create(false, UnitTests);

        private static IPersistenceConfigurer DatabaseConfigurer()
        {
            IPersistenceConfigurer configurer;

            if (UnitTests)
            {
                _log.Debug(m => m("Creating a Unit Test DB configuration..."));
                configurer = MsSqlCeConfiguration
                    .MsSqlCe40.ConnectionString("Data Source=test.sdf");
            }
            else
            {
                var c = ConfigurationManager.ConnectionStrings["db_SUGGESTIONBOX"].ConnectionString;

                _log.Debug(m => m("Database: {0}", c));

                configurer = MsSqlConfiguration.MsSql2012.ConnectionString(c);
            }

            return configurer;
        }
    }
}
