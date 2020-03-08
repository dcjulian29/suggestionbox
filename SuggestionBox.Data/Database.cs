using System;
using System.Configuration;
using System.Reflection;
using Common.Logging;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ToolKit.Data.NHibernate;
using Configuration = NHibernate.Cfg.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace SuggestionBox.Data
{
    /// <summary>
    ///   Provides Session Managers for the various databases that this applications uses.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Database : NHibernateDatabaseBase
    {
        private static readonly ILog _log = LogManager.GetLogger<Database>();
        private static readonly string _sessionName = "Database-SuggestionBox";

        static Database() => new Database();

        /// <summary>
        ///   Initializes a new instance of the <see cref="Database" /> class.
        /// </summary>
        public Database() : base(Assembly.GetAssembly(typeof(Database)))
        {
        }

        /// <summary>
        ///   Return the Session Factory for this application.
        /// </summary>
        /// <returns>the Session Factory</returns>
        public new static ISessionFactory SessionFactory
        {
            get
            {
                return Instance.SessionFactory(_sessionName);
            }
        }

        /// <summary>
        ///   This method will Initializes the database.
        /// </summary>
        /// <param name="initialization">The code to execute to Initialize Database</param>
        public override void InitializeDatabase(Action initialization)
        {
        }

        protected override IPersistenceConfigurer DatabaseConfigurer()
        {
            var c = ConfigurationManager.ConnectionStrings["db_SUGGESTIONBOX"].ConnectionString;

            _log.Debug(m => m("Database: {0}", c));

            return MsSqlConfiguration.MsSql2012.ConnectionString(c);
        }
    }
}
