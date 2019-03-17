using System;
using ToolKit.Data;

namespace SuggestionBox.Data.Entities
{
    /// <summary>
    /// Home Page Visit Statistics Data Model
    /// </summary>
    public class HomePageVisit : Entity
    {
        /// <summary>
        /// Gets or sets the hashed IP address of the visitor.
        /// </summary>
        /// <remarks>
        /// Only store the hashed IP address to prevent the ability to trace back to the original IP Address.
        /// </remarks>
        public virtual String HashedIpAddress { get; set; }

        /// <summary>
        /// Gets or sets the date and time of the last visit.
        /// </summary>
        public virtual DateTime LastVisit { get; set; }

        /// <summary>
        /// Gets or sets the number of visits.
        /// </summary>
        public virtual Int32 NumberOfVisits { get; set; }
    }
}
