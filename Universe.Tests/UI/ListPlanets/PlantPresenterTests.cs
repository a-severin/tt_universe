using System;
using System.Diagnostics.CodeAnalysis;
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
            var presenter = new PlanetPresenter(new AsyncPlanet(universe.Planets().Create(name)));

            Assert.IsNotNull(presenter.DeleteItem);
            Assert.IsNotNull(presenter.EditName);
            Assert.AreEqual(name, presenter.Text);
        }
    }
}
