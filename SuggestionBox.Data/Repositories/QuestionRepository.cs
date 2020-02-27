using System;
using System.Collections.Generic;
using System.Linq;
using SuggestionBox.Data.Entities;
using ToolKit.Data;
using ToolKit.Data.NHibernate;

namespace SuggestionBox.Data.Repositories
{
    /// <summary>
    ///     Implementation of the Question Repository
    /// </summary>
    public class QuestionRepository : Repository<Question, Int32>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="QuestionRepository" /> class.
        /// </summary>
        public QuestionRepository() =>
            Context = new NHibernateUnitOfWork(Database.SessionFactory.OpenSession());

        /// <summary>
        ///     Gets the active questions.
        /// </summary>
        /// <returns>The active questions.</returns>
        public List<Question> GetActiveQuestions() => Context.Get<Question>().Where(q => q.Active).ToList();

        /// <summary>
        ///     Gets all questions.
        /// </summary>
        /// <returns>All questions.</returns>
        public List<Question> GetAllQuestions() => FindAll().ToList();
    }
}
