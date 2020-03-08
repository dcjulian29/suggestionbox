using System;
using ToolKit.Data;

namespace SuggestionBox.Data.Entities
{
    /// <summary>
    ///   Comment Entity
    /// </summary>
    public class Comment : Entity
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="Comment" /> class.
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
        ///   Initializes a new instance of the <see cref="Comment" /> class.
        /// </summary>
        /// <param name="text">The text of the comment</param>
        // ReSharper disable DoNotCallOverridableMethodsInConstructor
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors",
            Justification = "Entities Always Have Virtual Members")]
        public Comment(string text)
        {
            Blocked = false;
            Liked = 0;
            WhenPosted = DateTime.Now;
            Text = text;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="Comment" /> class.
        /// </summary>
        /// <param name="text">The text of the comment.</param>
        /// <param name="question">The question that this comment belongs to.</param>
        // ReSharper disable DoNotCallOverridableMethodsInConstructor
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors",
            Justification = "Entities Always Have Virtual Members")]
        public Comment(string text, Question question)
        {
            Blocked = false;
            Liked = 0;
            WhenPosted = DateTime.Now;
            Text = text;
            ParentQuestion = question;
        }

        /// <summary>
        ///   Gets or sets a value indicating whether this <see cref="Comment" /> is blocked.
        /// </summary>
        public virtual bool Blocked { get; protected set; }

        /// <summary>
        ///   Gets or sets the number of people who like this comment.
        /// </summary>
        public virtual int Liked { get; protected set; }

        /// <summary>
        ///   Gets or sets the parent question of this comment
        /// </summary>
        public virtual Question ParentQuestion { get; set; }

        /// <summary>
        ///   Gets or sets the text of the comment.
        /// </summary>
        public virtual string Text { get; set; }

        /// <summary>
        ///   Gets or sets when this comment was posted.
        /// </summary>
        public virtual DateTime WhenPosted { get; protected set; }

        /// <summary>
        ///   Blocks this comment from being displayed.
        /// </summary>
        public void Block()
        {
            Blocked = true;
        }

        /// <summary>
        ///   Like the Comment.
        /// </summary>
        public void Like()
        {
            Liked++;
        }
    }
}
