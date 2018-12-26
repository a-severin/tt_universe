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
    public class ListPlanetsViewModelTests : BaseUniverseTests
    {
        [TestMethod]
        public void Constructor_NotEmptyCollection()
        {
            Assert.IsTrue(new ListPlanetsViewModel(
                new TestDataUniverse(universe)
            ).PlanetPresenters.Any());
        }

        [TestMethod]
        public void Constructor_InitializeCommands()
        {
            Assert.IsNotNull(new ListPlanetsViewModel(universe).CreatePlanet);
        }

        [TestMethod]
        public void CreateCommand_CanExecute_NotEmptyParameter()
        {
            var createPlanet = new CreatePlanet(new AsyncPlanets(universe.Planets()));

            Assert.IsTrue(createPlanet.CanExecute("Test"));
        }

        [TestMethod]
        public async Task CreateCommand_AddPlanet_NotEmptyParameter()
        {
            var planets = new AsyncPlanets(universe.Planets());
            var eventInvoked = false;
            planets.NewPlanetEvent += (sender, args) => eventInvoked = true;
            var createPlanet = new CreatePlanet(planets);

            await createPlanet.ExecuteAsync("Test");

            Assert.IsTrue(planets.Any());
            Assert.IsTrue(eventInvoked);
        }
        
    }
}