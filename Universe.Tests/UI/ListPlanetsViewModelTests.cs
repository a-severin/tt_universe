using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Universe.Model;
using Universe.UI.ListPlanets;

namespace Universe.Tests.UI
{
    [TestClass]
    public class ListPlanetsViewModelTests: BaseUniverseTests
    {
        [TestMethod]
        public void Constructor_NotEmptyCollection()
        {
            Assert.IsTrue(new ListPlanetsViewModel(
                new TestDataUniverse(universe)
            ).PlanetPresenters.Any());
        }
    }
}