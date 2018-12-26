using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Universe.Model;
using Universe.UI.PlanetDescription;

namespace Universe.Tests.UI.PlanetDescription
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class PlanetDescriptionViewModelTests: BaseUniverseTests
    {
        [TestMethod]
        public void Constructor_Initialize()
        {
            var dataUniverse = new TestDataUniverse(universe);
            var vm = new PlanetDescriptionViewModel(dataUniverse);

            vm.ShowPlanetDescription(null, dataUniverse.Planets().First());

            Assert.IsTrue(vm.AvailableToAddProperties.Any());
            Assert.IsTrue(vm.PlanetProperties.Any());
            Assert.IsNotNull(vm.AddProperty);
        }

        [TestMethod]
        public void AddProperty_CanExecute_AfterSelectAvailableProperty()
        {
            var dataUniverse = new TestDataUniverse(universe);
            var vm = new PlanetDescriptionViewModel(dataUniverse);

            vm.ShowPlanetDescription(null, dataUniverse.Planets().First());
            vm.SelectedAvailableProperty = vm.AvailableToAddProperties.First();

            Assert.IsTrue(vm.AddProperty.CanExecute(null));
        }


        [TestMethod]
        public void AddProperty_AddProperty_AfterExecute()
        {
            var dataUniverse = new TestDataUniverse(universe);
            var vm = new PlanetDescriptionViewModel(dataUniverse);

            var planet = dataUniverse.Planets().First();
            vm.ShowPlanetDescription(null, planet);
            vm.SelectedAvailableProperty = vm.AvailableToAddProperties.First();
            var prop = vm.SelectedAvailableProperty.Property;
            vm.AddProperty.Execute(null);
           
            Assert.IsTrue(planet.Properties().Contains(prop));
        }
    }
}
