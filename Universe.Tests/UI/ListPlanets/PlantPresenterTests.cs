using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Universe.Model;
using Universe.UI.ListPlanets;

namespace Universe.Tests.UI.ListPlanets
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class PlantPresenterTests: BaseUniverseTests
    {
        [TestMethod]
        public void Constructor_Initialize()
        {
            var name = "Test";
            var presenter = new PlanetPresenter(new AsyncPlanet(universe.Planets().Create(name)), presenter1 => { });

            Assert.IsNotNull(presenter.DeleteItem);
            Assert.IsNotNull(presenter.EditName);
            Assert.AreEqual(name, presenter.Text);
        }

        [TestMethod]
        public async Task EditPlanetName_Execute_ChangeName()
        {
            var name = "Test";
            var asyncPlanet = new AsyncPlanet(universe.Planets().Create(name));
            var command = new EditPlanetName(asyncPlanet);

            name = "Test2";

            Assert.IsTrue(command.CanExecute(name));

            await command.ExecuteAsync(name);

            Assert.AreEqual(name, asyncPlanet.Name());
        }

        [TestMethod]
        public async Task DeletePlanet_Execute_RemovePlanet()
        {
            var command = new DeletePlanet(new AsyncPlanet(universe.Planets().Create("")));

            Assert.IsTrue(command.CanExecute(null));

            await command.ExecuteAsync(null);

            Assert.IsFalse(universe.Planets().Any());
        }
    }
}
