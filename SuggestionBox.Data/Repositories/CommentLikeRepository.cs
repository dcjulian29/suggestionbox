using SuggestionBox.Data.Entities;
using ToolKit.Data;
using ToolKit.Data.NHibernate;

namespace SuggestionBox.Data.Repositories
{
    /// <summary>
    /// Comment Like Repository
    /// </summary>
    public class CommentLikeRepository : Repository<CommentLike, int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentLikeRepository"/> class.
        /// </summary>
        public CommentLikeRepository()
        {
            if (!SessionPool.Contains("feedback"))
            {
                SessionPool.Add("feedback", Database.Feedback);
            }

            Context = new NHibernateUnitOfWork(SessionPool.Session("feedback"));
        }
    }
}
