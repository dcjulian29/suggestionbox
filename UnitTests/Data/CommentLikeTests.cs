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
    public class CommentLikeTests
    {
        [Fact]
        public void AcceptLike_Should_AcceptALike()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var like = new CommentLike();

            // Act
            _ = like.AcceptLike();

            // Assert
            Assert.True(now < like.LastTimeLiked);
        }

        [Fact]
        public void AcceptLike_Should_RejectRepeatedLikes()
        {
            // Arrange
            DateTime now;
            var like = new CommentLike();

            // Act
            _ = like.AcceptLike();
            now = DateTime.UtcNow;
            _ = like.AcceptLike();

            // Assert
            Assert.True(now > like.LastTimeLiked);
        }

        [Fact]
        public void AcceptLike_Should_ReturnFalse_When_RepeatedLikes()
        {
            // Arrange
            var like = new CommentLike();

            // Act
            _ = like.AcceptLike();
            var actual = like.AcceptLike();

            // Assert
            Assert.False(actual);
        }

        [Fact]
        public void AcceptLike_Should_ReturnTrue()
        {
            // Arrange
            var like = new CommentLike();

            // Act
            var actual = like.AcceptLike();

            // Assert
            Assert.True(actual);
        }
    }
}
