using System;
using SuggestionBox.Data.Entities;
using ToolKit.Data;
using ToolKit.Data.NHibernate;

namespace SuggestionBox.Data.Repositories
{
    /// <summary>
    /// Comment Like Repository
    /// </summary>
    public class CommentLikeRepository : Repository<CommentLike, Int32>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentLikeRepository"/> class.
        /// </summary>
        public CommentLikeRepository() =>
            Context = new NHibernateUnitOfWork(Database.SessionFactory.OpenSession());
    }
}
