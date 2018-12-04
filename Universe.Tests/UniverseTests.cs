using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Universe.Model;

namespace Universe.Tests
{
    [TestClass]
    public class UniverseTests
    {
        private IUniverse _universe;

        [TestMethod]
        public void Planets_Empty_AfterDelete()
        {
            _universe.Planets().Create("Test Planet");
            _universe.Planets().First().Delete();
            Assert.IsFalse(_universe.Planets().Any());
        }

        [TestMethod]
        public void Planets_NotEmpty_AfterCreateOne()
        {
            _universe.Planets().Create("Test Planet");
            Assert.IsTrue(_universe.Planets().Any());
        }

        [TestMethod]
        public void Properties_Empty_AfterDelete()
        {
            _universe.Properties().Create("Test Property");
            _universe.Properties().First().Delete();
            Assert.IsFalse(_universe.Properties().Any());
        }

        [TestMethod]
        public void Properties_NotEmpty_AfterCreateOne()
        {
            _universe.Properties().Create("Test Property");
            Assert.IsTrue(_universe.Properties().Any());
        }

        [TestInitialize]
        public void Setup()
        {
            _universe = new Model.InMemory.Universe();
        }
    }
}