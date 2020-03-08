using System;
using System.Diagnostics.CodeAnalysis;
using SuggestionBox.Data.Entities;
using Xunit;

namespace UnitTests.Data
{
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:ElementsMustBeDocumented",
        Justification = "Test Suites do not need XML Documentation.")]
    public class CommentTests
    {
        [Fact]
        public void Block_Should_SetCommentToBeBlocked()
        {
            // Arrange
            var comment = new Comment();

            // Act
            comment.Block();

            // Assert
            Assert.True(comment.Blocked);
        }

        [Fact]
        public void Liked_Should_ReturnOne_When_Liked()
        {
            // Arrange
            var comment = new Comment();

            // Act
            comment.Like();

            // Assert
            Assert.Equal(1, comment.Liked);
        }

        [Fact]
        public void Liked_Should_ReturnZero_When_Created()
        {
            // Arrange & Act
            var comment = new Comment();

            // Assert
            Assert.Equal(0, comment.Liked);
        }

        [Fact]
        public void ParentQuestion_Should_ReturnParentQeustion()
        {
            // Arrange & Act
            var question = new Question();
            var text = "This is the comment text";
            var comment = new Comment(text, question);

            // Assert
            Assert.Equal(question, comment.ParentQuestion);
        }

        [Fact]
        public void Text_Should_ReturnCommentText()
        {
            // Arrange & Act
            var text = "This is the comment text";
            var comment = new Comment(text);

            // Assert
            Assert.Equal(text, comment.Text);
        }

        [Fact]
        public void WhenPosted_Should_ReturtCurrentTime_When_Created()
        {
            // Arrange
            var expected = DateTime.Now;
            var comment = new Comment();

            // Act
            var actual = comment.WhenPosted;

            // Assert
            Assert.True(expected < actual);
        }
    }
}
