using SuggestionBox.Data.Entities;
using ToolKit.Data.NHibernate;

namespace SuggestionBox.Data.Repositories
{
    /// <summary>
    /// Implementation of the Comment Repository
    /// </summary>
    public class CommentRepository : NHibernateRepositoryBase<Comment, int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentRepository"/> class.
        /// </summary>
        public CommentRepository()
        {
            if (!SessionPool.Contains("feedback"))
            {
                SessionPool.Add("feedback", Database.Feedback);
            }

            Context = new NHibernateUnitOfWork(SessionPool.Session("feedback"));
        }
    }
}
