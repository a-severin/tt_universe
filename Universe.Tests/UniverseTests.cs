using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Universe.Model;

namespace Universe.Tests
{
    [TestClass]
    public class UniverseTests
    {
        private IUniverse _universe;

        [TestInitialize]
        public void Setup()
        {
            _universe = new Model.InMemory.Universe();
        }

        [TestMethod]
        public void Planets_Empty_AtStart()
        {
            Assert.IsFalse(_universe.Planets().Any());
        }

        [TestMethod]
        public void Properties_Empty_AtStart()
        {
            Assert.IsFalse(_universe.Properties().Any());
        }

        [TestMethod]
        public void Planets_NotEmpty_AfterCreateOne()
        {
            _universe.Planets().Create("Test Planet");
            Assert.IsTrue(_universe.Planets().Any());
        }
    }
}