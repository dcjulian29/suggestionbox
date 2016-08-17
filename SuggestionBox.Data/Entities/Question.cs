using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ToolKit.Data;

namespace SuggestionBox.Data.Entities
{
    /// <summary>
    /// Question Entity
    /// </summary>
    public class Question : Entity
    {
        private static Common.Logging.ILog _log = Common.Logging.LogManager.GetLogger<Question>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Question"/> class
        /// </summary>
        // ReSharper disable DoNotCallOverridableMethodsInConstructor
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors",
            Justification = "Entities Always Have Virtual Members")]
        public Question()
        {
            Comments = new List<Comment>();
            Active = true;
            Liked = 0;
            WhenPosted = DateTime.Now;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Question"/> is active.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        [DisplayName("Is this Question Active?")]
        public virtual bool Active { get; set; }

        /// <summary>
        /// Gets or sets the body of this question.
        /// </summary>
        /// <value>The body of this question.</value>
        [Required]
        [DisplayName("Question Body")]
        [DataType(DataType.MultilineText)]
        public virtual string Body { get; set; }

        /// <summary>
        /// Gets or sets the comments associated with this question
        /// </summary>
        public virtual IList<Comment> Comments { get; protected set; }

        /// <summary>
        /// Gets or sets the number of people who like this question.
        /// </summary>
        /// <value>The liked.</value>
        public virtual int Liked { get; set; }

        /// <summary>
        /// Gets or sets the subject of this question.
        /// </summary>
        /// <value>The subject of this question.</value>
        [Required]
        [DisplayName("Question Subject")]
        [StringLength(100, ErrorMessage = "Maximum Length is 100 characters.")]
        [DataType(DataType.Text)]
        public virtual string Subject { get; set; }

        /// <summary>
        /// Gets or sets when this question was posted.
        /// </summary>
        /// <value>The date and time this question was posted.</value>
        public virtual DateTime WhenPosted { get; set; }

        /// <summary>
        /// Add a comment to this question
        /// </summary>
        /// <param name="comment">The comment.</param>
        public virtual void AddComment(Comment comment)
        {
            _log.DebugFormat("Adding comment to Question: {0}", comment.Text);

            comment.ParentQuestion = this;
            this.Comments.Add(comment);
        }
    }
}
