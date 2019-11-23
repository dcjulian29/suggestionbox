using System.Data;
using NHibernate.Dialect;

namespace SuggestionBox.Data
{
    /// <summary>
    /// Represents a dialect of SQL CE that has been extended to support the XML database type
    /// </summary>
    public class UnitTestSqlCeDialect : MsSqlCe40Dialect
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitTestSqlCeDialect"/> class.
        /// </summary>
        public UnitTestSqlCeDialect()
            : base() => RegisterColumnType(DbType.Xml, "NTEXT");
    }
}
