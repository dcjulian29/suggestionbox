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
    /// Question NHibernate Mapping
    /// </summary>
    public class QuestionMap : ClassMap<Question>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionMap"/> class.
        /// </summary>
        public QuestionMap()
        {
            Table("Questions");

            Id(x => x.Id);

            Map(x => x.Active);
            Map(x => x.Body);
            Map(x => x.Liked);
            Map(x => x.Subject);
            Map(x => x.WhenPosted);

            HasMany(x => x.Comments)
              .KeyColumn("ParentQuestion")
              .Not.LazyLoad()
              .Cascade.All();
        }
    }
}
