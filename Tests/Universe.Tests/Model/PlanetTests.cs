using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Universe.Model;

namespace Universe.Tests.Model
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class PlanetTests : BaseUniverseTests
    {
        [TestMethod]
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public void Rename_ChangeName(UniverseSources source)
        {
            var planet = new TestDataUniverse(Universe(source)).Planets().First();

            var name = "Test";

            planet.Rename(name);
            Assert.AreEqual(name, planet.Name());
        }
    }
}