using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using SuggestionBox.Data.Entities;
using Xunit;

namespace UnitTests.Data
{
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:ElementsMustBeDocumented",
        Justification = "Test Suites do not need XML Documentation.")]
    public class QuestionTests
    {
        [Fact]
        public void Active_Should_ReturnTrue_When_Created()
        {
            // Arrange & Act
            var question = new Question();

            // Assert
            Assert.True(question.Active);
        }

        [Fact]
        public void AddComment_Should_AddTheProvidedComment()
        {
            // Arrange
            var expected = "This is a comment";
            var comment = new Comment(expected);
            var question = new Question();

            // Act
            question.AddComment(comment);

            // Assert
            Assert.Equal(expected, question.Comments.FirstOrDefault()?.Text);
        }

        [Fact]
        public void Body_Should_ReturnBody_When_CreatedWithSubjectAndBody()
        {
            // Arrange
            var subject = "This is a Suggestion";
            var body = "This is the body of the suggestion";

            // Act
            var question = new Question(subject, body);

            // Assert
            Assert.Equal(body, question.Body);
        }

        [Fact]
        public void Comments_Should_BeEmpty_When_Created()
        {
            // Arrange & Act
            var question = new Question();

            // Assert
            Assert.Equal(0, question.Comments.Count);
        }

        [Fact]
        public void Liked_Should_ReturnOne_When_Liked()
        {
            // Arrange
            var question = new Question();

            // Act
            question.Like();

            // Assert
            Assert.Equal(1, question.Liked);
        }

        [Fact]
        public void Liked_Should_ReturnTrue_When_Created()
        {
            // Arrange & Act
            var question = new Question();

            // Assert
            Assert.Equal(0, question.Liked);
        }

        [Fact]
        public void Subject_Should_ReturnSubject_When_CreatedWithSubjectAndBody()
        {
            // Arrange
            var subject = "This is a Suggestion";
            var body = "This is the body of the suggestion";

            // Act
            var question = new Question(subject, body);

            // Assert
            Assert.Equal(subject, question.Subject);
        }

        [Fact]
        public void WhenPosted_Should_ReturtCurrentTime_When_Created()
        {
            // Arrange
            var expected = DateTime.Now;
            var question = new Question();

            // Act
            var actual = question.WhenPosted;

            // Assert
            Assert.True(expected < actual);
        }
    }
}
