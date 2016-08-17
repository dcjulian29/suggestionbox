using ToolKit.Data.NHibernate;
using ToolKit.Data.NHibernate.SessionFactories;

namespace SuggestionBox.Data
{
    /// <summary>
    /// Provides Session Managers for the various databases that this applications uses.
    /// </summary>
    public static class Database
    {
        /// <summary>
        /// Gets the session manager for the Feedback database.
        /// </summary>
        public static SessionManager Feedback
        {
            get
            {
                return new SessionManager(new SqLiteSessionFactory("db_FEEDBACK"));
            }
        }
    }
}
