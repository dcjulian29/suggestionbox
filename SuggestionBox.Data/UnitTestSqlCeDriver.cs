using System.Data;
using System.Data.Common;
using System.Data.SqlServerCe;
using NHibernate.Driver;
using NHibernate.SqlTypes;

namespace SuggestionBox.Data
{
    /// <summary>
    /// A NHibernate driver for Microsoft SQL Server CE data provider that adds support to use XML
    /// types directly in the code.
    /// </summary>
    public class UnitTestSqlCeDriver : SqlServerCeDriver
    {
        /// <summary>
        /// Initialize the parameter based on the database type
        /// </summary>
        /// <param name="param">Represents the parameter to the command object.</param>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="databaseType">Represents the database type of the parameter.</param>
        protected override void InitializeParameter(DbParameter param, string name, SqlType databaseType)
        {
            if (databaseType is XmlSqlType)
            {
                base.InitializeParameter(param, name, new StringSqlType());

                var parameter = (SqlCeParameter)param;
                parameter.SqlDbType = SqlDbType.NText;
            }
            else
            {
                base.InitializeParameter(param, name, databaseType);
            }
        }
    }
}
