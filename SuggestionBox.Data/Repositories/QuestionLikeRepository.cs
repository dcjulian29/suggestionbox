using SuggestionBox.Data.Entities;
using ToolKit.Data.NHibernate;

namespace SuggestionBox.Data.Repositories
{
    /// <summary>
    /// Question Like Repository
    /// </summary>
    public class QuestionLikeRepository : NHibernateRepositoryBase<QuestionLike, int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionLikeRepository"/> class.
        /// </summary>
        public QuestionLikeRepository()
        {
            if (!SessionPool.Contains("feedback"))
            {
                SessionPool.Add("feedback", Database.Feedback);
            }

            Context = new NHibernateUnitOfWork(SessionPool.Session("feedback"));
        }
    }
}
