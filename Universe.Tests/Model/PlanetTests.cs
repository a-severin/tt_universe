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
        public void Rename_ChangeName()
        {
            var planet = new TestDataUniverse(universe).Planets().First();

            var name = "Test";

            planet.Rename(name);
            Assert.AreEqual(name, planet.Name());
        }
    }
}