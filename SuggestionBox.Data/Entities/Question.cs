using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common.Logging;
using ToolKit.Data;

namespace SuggestionBox.Data.Entities
{
    /// <summary>
    ///   Question Entity
    /// </summary>
    public class Question : Entity
    {
        private static readonly ILog _log = LogManager.GetLogger<Question>();

        /// <summary>
        ///   Initializes a new instance of the <see cref="Question" /> class
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
        ///   Initializes a new instance of the <see cref="Question" /> class
        /// </summary>
        // ReSharper disable DoNotCallOverridableMethodsInConstructor
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors",
            Justification = "Entities Always Have Virtual Members")]
        public Question(string subject, string body)
        {
            Comments = new List<Comment>();
            Active = true;
            Liked = 0;
            WhenPosted = DateTime.Now;
            Subject = subject;
            Body = body;
        }

        /// <summary>
        ///   Gets or sets a value indicating whether this <see cref="Question" /> is active.
        /// </summary>
        [DisplayName("Is this Question Active?")]
        public virtual bool Active { get; set; }

        /// <summary>
        ///   Gets or sets the body of this question.
        /// </summary>
        [Required]
        [DisplayName("Question Body")]
        [DataType(DataType.MultilineText)]
        public virtual string Body { get; set; }

        /// <summary>
        ///   Gets or sets the comments associated with this question
        /// </summary>
        public virtual IList<Comment> Comments { get; protected set; }

        /// <summary>
        ///   Gets or sets the number of people who like this question.
        /// </summary>
        public virtual int Liked { get; protected set; }

        /// <summary>
        ///   Gets or sets the subject of this question.
        /// </summary>
        [Required]
        [DisplayName("Question Subject")]
        [StringLength(100, ErrorMessage = "Maximum Length is 100 characters.")]
        [DataType(DataType.Text)]
        public virtual string Subject { get; set; }

        /// <summary>
        ///   Gets or sets when this question was posted.
        /// </summary>
        public virtual DateTime WhenPosted { get; set; }

        /// <summary>
        ///   Add a comment to this question
        /// </summary>
        /// <param name="comment">The comment.</param>
        public virtual void AddComment(Comment comment)
        {
            _log.DebugFormat("Adding comment to Question: {0}", comment.Text);

            comment.ParentQuestion = this;

            Comments.Add(comment);
        }

        /// <summary>
        ///   Like the Comment.
        /// </summary>
        public virtual void Like()
        {
            Liked++;
        }
    }
}
