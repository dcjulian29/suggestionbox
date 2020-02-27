using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using NHibernate;
using SuggestionBox.Data;
using SuggestionBox.Data.Entities;
using ToolKit.Cryptography;
using ToolKit.Data.NHibernate.UnitTests;

namespace UnitTests
{
    [SuppressMessage(
    "StyleCop.CSharp.DocumentationRules",
    "SA1600:ElementsMustBeDocumented",
    Justification = "Test Suites do not need XML Documentation.")]
    public class TestDatabase : UnitTestDatabase
    {
        static TestDatabase() => new TestDatabase();

        public TestDatabase() : base(Assembly.GetAssembly(typeof(Database)), InitializeUnitTestDatabase)
        {
        }

        public new static ISessionFactory SessionFactory
        {
            get
            {
                return Instance.SessionFactory("UnitTest-SuggestionBox");
            }
        }

        public static void InitializeUnitTestDatabase()
        {
            using (var session = SessionFactory.OpenSession())
            {
                _ = session.CreateSQLQuery("DELETE FROM CommentLikes").ExecuteUpdate();
                _ = session.CreateSQLQuery("DELETE FROM Comments").ExecuteUpdate();
                _ = session.CreateSQLQuery("DELETE FROM HomePageVisits").ExecuteUpdate();
                _ = session.CreateSQLQuery("DELETE FROM QuestionLikes").ExecuteUpdate();
                _ = session.CreateSQLQuery("DELETE FROM Questions").ExecuteUpdate();
                _ = session.Close();
            }

            using (var session = SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var homePageVisit = new HomePageVisit
                    {
                        HashedIpAddress = SHA256Hash.Create().Compute("127.0.0.1"),
                        LastVisit = DateTime.UtcNow,
                        NumberOfVisits = 2
                    };

                    _ = session.Save(homePageVisit);

                    transaction.Commit();
                }

                _ = session.Close();
            }
        }
    }
}
