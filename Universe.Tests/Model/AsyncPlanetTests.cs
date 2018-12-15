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
    public class AsyncPlanetTests : BaseUniverseTests
    {
        [TestMethod]
        public async Task RenameAsync_InvokeEvent()
        {
            var planet = new AsyncPlanet(universe.Planets().Create(""));
            var invoked = false;
            planet.PlanetRenamed += (sender, args) => invoked = true;

            var name = "Test";
            await planet.RenameAsync(name);

            Assert.AreEqual(name, await planet.NameAsync());
            Assert.IsTrue(invoked);
        }

        [TestMethod]
        public async Task DeleteAsync_InvokeEvent()
        {
            var planets = universe.Planets();
            var planet = new AsyncPlanet(planets.Create(""));
            var invoked = false;
            planet.PlanetDeleted += (sender, args) => invoked = true;

            await planet.DeleteAsync();

            Assert.IsTrue(invoked);
            Assert.IsFalse(planets.Any());
        }

        [TestMethod]
        public void Rename_InvokeEvent()
        {
            var planet = new AsyncPlanet(universe.Planets().Create(""));
            var invoked = false;
            planet.PlanetRenamed += (sender, args) => invoked = true;

            var name = "Test";
            planet.Rename(name);

            Assert.AreEqual(name, planet.Name());
            Assert.IsTrue(invoked);
        }

        [TestMethod]
        public void Delete_InvokeEvent()
        {
            var planets = universe.Planets();
            var planet = new AsyncPlanet(planets.Create(""));
            var invoked = false;
            planet.PlanetDeleted += (sender, args) => invoked = true;

            planet.Delete();

            Assert.IsTrue(invoked);
            Assert.IsFalse(planets.Any());
        }
    }
}