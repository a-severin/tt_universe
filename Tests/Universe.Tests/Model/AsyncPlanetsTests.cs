using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Universe.Model;

namespace Universe.Tests.Model
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class AsyncPlanetsTests: BaseUniverseTests
    {
        [TestMethod]
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public async Task CreateAsync_InvokeEvent(UniverseSources source)
        {
            var name = "TestPlanetName";
            var asyncPlanets = new AsyncPlanets(Universe(source).Planets());
            var eventInvoked = false;
            asyncPlanets.NewPlanetEvent += (sender, args) => { eventInvoked = true; };

            var planet = await asyncPlanets.CreateAsync(name);

            Assert.AreEqual(name, planet.Name());
            Assert.IsTrue(eventInvoked);
            Assert.IsTrue(asyncPlanets.Any());
        }

        [TestMethod]
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public void Create_InvokeEvent(UniverseSources source)
        {
            var name = "TestPlanetName";
            var asyncPlanets = new AsyncPlanets(Universe(source).Planets());
            var eventInvoked = false;
            asyncPlanets.NewPlanetEvent += (sender, args) => { eventInvoked = true; };

            var planet = asyncPlanets.Create(name);

            Assert.AreEqual(name, planet.Name());
            Assert.IsTrue(eventInvoked);
            Assert.IsTrue(asyncPlanets.Any());
        }

        [TestMethod]
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public void Planets_Empty_AfterDelete(UniverseSources source)
        {
            var asyncPlanets = new AsyncPlanets(Universe(source).Planets());
            asyncPlanets.Create("Test Planet");
            asyncPlanets.First().Delete();
            Assert.IsFalse(asyncPlanets.Any());
        }

        [TestMethod]
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public void Planets_NotEmpty_AfterCreateOne(UniverseSources source)
        {
            var asyncPlanets = new AsyncPlanets(Universe(source).Planets());
            asyncPlanets.Create("Test Planet");
            Assert.IsTrue(asyncPlanets.Any());
        }
    }
}
