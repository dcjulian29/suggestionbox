using System;
using ToolKit.Data;

namespace SuggestionBox.Data.Entities
{
    /// <summary>
    /// Comment Entity
    /// </summary>
    public class Comment : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Comment"/> class.
        /// </summary>
        // ReSharper disable DoNotCallOverridableMethodsInConstructor
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors",
            Justification = "Entities Always Have Virtual Members")]
        public Comment()
        {
            Blocked = false;
            Liked = 0;
            WhenPosted = DateTime.Now;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Comment"/> is blocked.
        /// </summary>
        /// <value>
        ///   <c>true</c> if blocked; otherwise, <c>false</c>.
        /// </value>
        public virtual bool Blocked { get; set; }

        /// <summary>
        /// Gets or sets the number of people who like this comment.
        /// </summary>
        /// <value>
        /// The liked.
        /// </value>
        public virtual int Liked { get; set; }

        /// <summary>
        /// Gets or sets the parent question of this comment
        /// </summary>
        /// <value>
        /// The parent question of this comment
        /// </value>
        public virtual Question ParentQuestion { get; set; }

        /// <summary>
        /// Gets or sets the text of the comment.
        /// </summary>
        /// <value>
        /// The text of the comment.
        /// </value>
        public virtual string Text { get; set; }

        /// <summary>
        /// Gets or sets when this comment was posted.
        /// </summary>
        /// <value>
        /// The date and time when this comment was posted.
        /// </value>
        public virtual DateTime WhenPosted { get; set; }
    }
}
