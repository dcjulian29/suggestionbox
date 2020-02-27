using FluentNHibernate.Mapping;
using SuggestionBox.Data.Entities;

namespace SuggestionBox.Data.Mappings
{
    /// <summary>
    ///     QuestionLike NHibernate Mapping
    /// </summary>
    public class QuestionLikeMap : ClassMap<QuestionLike>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="QuestionLikeMap" /> class.
        /// </summary>
        public QuestionLikeMap()
        {
            Table("QuestionLikes");

            Id(x => x.Id);

            Map(x => x.HashedIpAddress);
            Map(x => x.LastTimeLiked);
            Map(x => x.QuestionId);
        }
    }
}
