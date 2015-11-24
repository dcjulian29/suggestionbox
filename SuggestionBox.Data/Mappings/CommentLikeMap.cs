using FluentNHibernate.Mapping;
using SuggestionBox.Data.Entities;

namespace SuggestionBox.Data.Mappings
{
    /// <summary>
    /// CommentLike NHibernate Mapping
    /// </summary>
    public class CommentLikeMap : ClassMap<CommentLike>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentLikeMap"/> class.
        /// </summary>
        public CommentLikeMap()
        {
            Table("CommentLikes");

            Id(x => x.Id);

            Map(x => x.HashedIpAddress);
            Map(x => x.LastTimeLiked);
            Map(x => x.CommentId);
        }
    }
}
