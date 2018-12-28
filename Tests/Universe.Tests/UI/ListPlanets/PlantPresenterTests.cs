using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Universe.Model;
using Universe.WPF.UI.ListPlanets;

namespace Universe.Tests.UI.ListPlanets
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class PlantPresenterTests: BaseUniverseTests
    {
        [TestMethod]
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public void Constructor_Initialize(UniverseSources source)
        {
            var name = "Test";
            var presenter = new PlanetPresenter(new AsyncPlanet(Universe(source).Planets().Create(name)), presenter1 => { });

            Assert.IsNotNull(presenter.DeleteItem);
            Assert.IsNotNull(presenter.EditName);
            Assert.AreEqual(name, presenter.Text);
        }

        [TestMethod]
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public async Task EditPlanetName_Execute_ChangeName(UniverseSources source)
        {
            var name = "Test";
            var asyncPlanet = new AsyncPlanet(Universe(source).Planets().Create(name));
            var command = new EditPlanetName(asyncPlanet);

            name = "Test2";

            Assert.IsTrue(command.CanExecute(name));

            await command.ExecuteAsync(name);

            Assert.AreEqual(name, asyncPlanet.Name());
        }

        [TestMethod]
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public async Task DeletePlanet_Execute_RemovePlanet(UniverseSources source)
        {
            var universe = Universe(source);
            var command = new DeletePlanet(new AsyncPlanet(universe.Planets().Create("")));

            Assert.IsTrue(command.CanExecute(null));

            await command.ExecuteAsync(null);

            Assert.IsFalse(universe.Planets().Any());
        }
    }
}
