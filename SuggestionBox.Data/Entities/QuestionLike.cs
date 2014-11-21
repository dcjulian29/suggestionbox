using System;
using ToolKit.Data;

namespace SuggestionBox.Data.Entities
{
    /// <summary>
    /// Question-Like Entity
    /// </summary>
    public class QuestionLike : Entity
    {
        /// <summary>
        /// Gets or sets the hashed IP address of the visitor.
        /// </summary>
        /// <value>
        /// The hashed IP address of the visitor.
        /// </value>
        /// <remarks>
        /// Only store the hashed IP address to prevent the ability to trace back
        /// to the original IP Address.
        /// </remarks>
        public virtual string HashedIpAddress { get; set; }

        /// <summary>
        /// Gets or sets the last time this question was liked.
        /// </summary>
        /// <value>
        /// The last time liked.
        /// </value>
        public virtual DateTime LastTimeLiked { get; set; }

        /// <summary>
        /// Gets or sets the ID of the question liked.
        /// </summary>
        /// <value>
        /// The ID of the question.
        /// </value>
        public virtual int QuestionId { get; set; }

        /// <summary>
        /// Determine if we should accept the like. If the last time this visitor liked this question
        /// was less than 10 minute (600 seconds), reject the like.
        /// </summary>
        /// <returns><c>true</c> if the caller should accept the like; otherwise, <c>false</c>.</returns>
        public virtual bool AcceptLike()
        {
            var elaspsed = DateTime.UtcNow - LastTimeLiked;
            var seconds = elaspsed.TotalSeconds;

            if (seconds < 600)
            {
                return false;
            }

            LastTimeLiked = DateTime.UtcNow;
            return true;
        }
    }
}
