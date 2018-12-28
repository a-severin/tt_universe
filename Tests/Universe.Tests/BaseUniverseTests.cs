using System.Data.SQLite;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Universe.Model;

namespace Universe.Tests
{
    [ExcludeFromCodeCoverage]
    public class BaseUniverseTests
    {
        protected IUniverse universe;

        [TestInitialize]
        public void Setup()
        {
#if SQLite
            universe = new Universe.Model.Sqlite.SqliteUniverse(new SQLiteConnection("Data Source=:memory:")
                .OpenAndReturn());
#else
             universe = new Universe.Model.InMemory.Universe();
#endif
        }
    }
}