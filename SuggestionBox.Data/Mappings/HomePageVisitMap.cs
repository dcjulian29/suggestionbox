using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SuggestionBox.Data.Entities;

namespace SuggestionBox.Data.Mappings
{
    /// <summary>
    /// HomePageVisit NHibernate Mapping
    /// </summary>
    public class HomePageVisitMap : ClassMap<HomePageVisit>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomePageVisitMap"/> class.
        /// </summary>
        public HomePageVisitMap()
        {
            Table("HomePageVisits");

            Id(x => x.Id);

            Map(x => x.HashedIpAddress);
            Map(x => x.LastVisit);
            Map(x => x.NumberOfVisits);
        }
    }
}
