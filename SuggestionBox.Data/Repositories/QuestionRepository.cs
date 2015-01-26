using System.Collections.Generic;
using System.Linq;
using SuggestionBox.Data.Entities;
using ToolKit.Data.NHibernate;

namespace SuggestionBox.Data.Repositories
{
    /// <summary>
    /// Implementation of the Question Repository
    /// </summary>
    public class QuestionRepository : NHibernateRepositoryBase<Question, int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionRepository"/> class.
        /// </summary>
        public QuestionRepository()
        {
            if (!SessionPool.Contains("feedback"))
            {
                SessionPool.Add("feedback", Database.Feedback);
            }

            Context = new NHibernateUnitOfWork(SessionPool.Session("feedback"));
        }

        /// <summary>
        /// Gets the active questions.
        /// </summary>
        /// <returns>
        /// The active questions.
        /// </returns>
        public List<Question> GetActiveQuestions()
        {
            return Context.Get<Question>().Where(q => q.Active).ToList();
        }

        /// <summary>
        /// Gets all questions.
        /// </summary>
        /// <returns>
        /// All questions.
        /// </returns>
        public List<Question> GetAllQuestions()
        {
            return FindAll().ToList();
        }
    }
}
