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
    public class ListPlanetsViewModelTests : BaseUniverseTests
    {
        [TestMethod]
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public void Constructor_NotEmptyCollection(UniverseSources source)
        {
            Assert.IsTrue(new ListPlanetsViewModel(
                new TestDataUniverse(Universe(source))
            ).PlanetPresenters.Any());
        }

        [TestMethod]
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public void Constructor_InitializeCommands(UniverseSources source)
        {
            Assert.IsNotNull(new ListPlanetsViewModel(Universe(source)).CreatePlanet);
        }

        [TestMethod]
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public void CreateCommand_CanExecute_NotEmptyParameter(UniverseSources source)
        {
            var createPlanet = new CreatePlanet(new AsyncPlanets(Universe(source).Planets()));

            Assert.IsTrue(createPlanet.CanExecute("Test"));
        }

        [TestMethod]
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public async Task CreateCommand_AddPlanet_NotEmptyParameter(UniverseSources source)
        {
            var planets = new AsyncPlanets(Universe(source).Planets());
            var eventInvoked = false;
            planets.NewPlanetEvent += (sender, args) => eventInvoked = true;
            var createPlanet = new CreatePlanet(planets);

            await createPlanet.ExecuteAsync("Test");

            Assert.IsTrue(planets.Any());
            Assert.IsTrue(eventInvoked);
        }
        
    }
}