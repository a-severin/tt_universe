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
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public async Task RenameAsync_InvokeEvent(UniverseSources source)
        {
            var planet = new AsyncPlanet(Universe(source).Planets().Create(""));
            var invoked = false;
            planet.PlanetRenamed += (sender, args) => invoked = true;

            var name = "Test";
            await planet.RenameAsync(name);

            Assert.AreEqual(name, await planet.NameAsync());
            Assert.IsTrue(invoked);
        }

        [TestMethod]
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public async Task DeleteAsync_InvokeEvent(UniverseSources source)
        {
            var planets = Universe(source).Planets();
            var planet = new AsyncPlanet(planets.Create(""));
            var invoked = false;
            planet.PlanetDeleted += (sender, args) => invoked = true;

            await planet.DeleteAsync();

            Assert.IsTrue(invoked);
            Assert.IsFalse(planets.Any());
        }

        [TestMethod]
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public void Rename_InvokeEvent(UniverseSources source)
        {
            var planet = new AsyncPlanet(Universe(source).Planets().Create(""));
            var invoked = false;
            planet.PlanetRenamed += (sender, args) => invoked = true;

            var name = "Test";
            planet.Rename(name);

            Assert.AreEqual(name, planet.Name());
            Assert.IsTrue(invoked);
        }

        [TestMethod]
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public void Delete_InvokeEvent(UniverseSources source)
        {
            var planets = Universe(source).Planets();
            var planet = new AsyncPlanet(planets.Create(""));
            var invoked = false;
            planet.PlanetDeleted += (sender, args) => invoked = true;

            planet.Delete();

            Assert.IsTrue(invoked);
            Assert.IsFalse(planets.Any());
        }
    }
}