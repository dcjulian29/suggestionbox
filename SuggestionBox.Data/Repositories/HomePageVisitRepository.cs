using System;
using System.Linq;
using SuggestionBox.Data.Entities;
using ToolKit.Data;
using ToolKit.Data.NHibernate;

namespace SuggestionBox.Data.Repositories
{
    /// <summary>
    ///     Implementation of the Home Page Visits Repository
    /// </summary>
    public class HomePageVisitRepository : Repository<HomePageVisit, Int32>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="HomePageVisitRepository" /> class.
        /// </summary>
        public HomePageVisitRepository() =>
            Context = new NHibernateUnitOfWork(Database.SessionFactory.OpenSession());

        /// <summary>
        ///     Gets a entity identified by the hashed IP address.
        /// </summary>
        /// <param name="ip">The hashed IP address.</param>
        /// <returns>A entity identified by the hashed IP address.</returns>
        public HomePageVisit GetByIp(string ip)
        {
            var visitors = from v in Context.Get<HomePageVisit>()
                           where v.HashedIpAddress == ip
                           select v;

            return visitors.FirstOrDefault();
        }
    }
}
