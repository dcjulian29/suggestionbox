using System;
using SuggestionBox.Data.Entities;
using ToolKit.Data;
using ToolKit.Data.NHibernate;

namespace SuggestionBox.Data.Repositories
{
    /// <summary>
    ///     Implementation of the Comment Repository
    /// </summary>
    public class CommentRepository : Repository<Comment, Int32>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CommentRepository" /> class.
        /// </summary>
        public CommentRepository() =>
            Context = new NHibernateUnitOfWork(Database.SessionFactory.OpenSession());
    }
}
