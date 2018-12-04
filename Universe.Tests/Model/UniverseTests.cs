using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Universe.Model;

namespace Universe.Tests.Model
{
    [TestClass]
    public class UniverseTests: BaseUniverseTests
    {

        [TestMethod]
        public void Planets_Empty_AfterDelete()
        {
            universe.Planets().Create("Test Planet");
            universe.Planets().First().Delete();
            Assert.IsFalse(universe.Planets().Any());
        }

        [TestMethod]
        public void Planets_NotEmpty_AfterCreateOne()
        {
            universe.Planets().Create("Test Planet");
            Assert.IsTrue(universe.Planets().Any());
        }

        [TestMethod]
        public void Properties_Empty_AfterDelete()
        {
            universe.Properties().Create("Test Property");
            universe.Properties().First().Delete();
            Assert.IsFalse(universe.Properties().Any());
        }

        [TestMethod]
        public void Properties_NotEmpty_AfterCreateOne()
        {
            universe.Properties().Create("Test Property");
            Assert.IsTrue(universe.Properties().Any());
        }

        
    }
}