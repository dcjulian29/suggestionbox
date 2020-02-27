using SuggestionBox.Data.Entities;
using SuggestionBox.Data.Repositories;
using System;
using System.Diagnostics.CodeAnalysis;
using ToolKit.Cryptography;
using Xunit;

namespace UnitTests.Data.Repositories
{
    [SuppressMessage(
    "StyleCop.CSharp.DocumentationRules",
    "SA1600:ElementsMustBeDocumented",
    Justification = "Test Suites do not need XML Documentation.")]
    public class HomePageVisitRepositoryTests
    {
        [Fact]
        public void GetByIp_Should_ReturnInitalResult()
        {
            // Arrange
            TestDatabase.InitializeUnitTestDatabase();

            var clientIp = SHA256Hash.Create().Compute("127.0.0.1");

            HomePageVisit actual;

            // Act
            using (var repository = new HomePageVisitRepository())
            {
                actual = repository.GetByIp(clientIp);
            }

            // Assert
            Assert.NotNull(actual);
        }

        [Fact]
        public void GetByIp_Should_ReturnNull_When_HomePageVisitDoesNotExist()
        {
            // Arrange
            TestDatabase.InitializeUnitTestDatabase();

            const string clientIp = "DOESNOTEXIST";

            HomePageVisit actual;

            // Act
            using (var repository = new HomePageVisitRepository())
            {
                actual = repository.GetByIp(clientIp);
            }

            // Assert
            Assert.Null(actual);
        }

        [Fact]
        public void GetByIp_Should_ReturnResultAfterSaving()
        {
            // Arrange
            TestDatabase.InitializeUnitTestDatabase();

            var clientIp = SHA256Hash.Create().Compute(DateTime.UtcNow.ToString());

            HomePageVisit actual;

            using (var repository = new HomePageVisitRepository())
            {
                var visitor = new HomePageVisit
                {
                    HashedIpAddress = clientIp,
                    LastVisit = DateTime.UtcNow,
                    NumberOfVisits = 1
                };

                repository.Save(visitor);
            }

            // Act
            using (var repository = new HomePageVisitRepository())
            {
                actual = repository.GetByIp(clientIp);
            }

            // Assert

            Assert.Equal(clientIp, actual.HashedIpAddress);
        }
    }
}
