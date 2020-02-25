using System;
using System.Configuration;
using System.Reflection;
using Common.Logging;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ToolKit.Data.NHibernate;
using Configuration = NHibernate.Cfg.Configuration;

namespace SuggestionBox.Data
{
    /// <summary>
    ///     Provides Session Managers for the various databases that this applications uses.
    /// </summary>
    public class Database : NHibernateDatabaseBase
    {
        private static readonly ILog _log = LogManager.GetLogger<Database>();
        private static readonly string _sessionName = "Database-SuggestionBox";

        static Database() => new Database();

        /// <summary>
        ///     Initializes a new instance of the <see cref="Database" /> class.
        /// </summary>
        public Database() : base(Assembly.GetAssembly(typeof(Database)))
        {
        }

        public new static ISessionFactory SessionFactory
        {
            get
            {
                return Instance.SessionFactory(_sessionName);
            }
        }

        public override void InitializeDatabase(Action initialization)
        {
            throw new NotImplementedException();
        }

        protected override IPersistenceConfigurer DatabaseConfigurer()
        {
            var c = ConfigurationManager.ConnectionStrings["db_SUGGESTIONBOX"].ConnectionString;

            _log.Debug(m => m("Database: {0}", c));

            return MsSqlConfiguration.MsSql2012.ConnectionString(c);
        }
    }
}
