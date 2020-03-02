using FluentNHibernate.Mapping;
using SuggestionBox.Data.Entities;

namespace SuggestionBox.Data.Mappings
{
    /// <summary>
    ///     Comment NHibernate Mapping
    /// </summary>
    public class CommentMap : ClassMap<Comment>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CommentMap" /> class.
        /// </summary>
        public CommentMap()
        {
            Table("Comments");

            Id(x => x.Id);

            Map(x => x.Blocked);
            Map(x => x.Text);
            Map(x => x.Liked);
            Map(x => x.WhenPosted);
        }
    }
}
