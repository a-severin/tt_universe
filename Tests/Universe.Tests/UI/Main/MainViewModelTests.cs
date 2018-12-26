using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Universe.WPF.UI.Main;

namespace Universe.Tests.UI.Main
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class MainViewModelTests: BaseUniverseTests
    {
        [TestMethod]
        public void Constructor_Initialize()
        {
            var vm = new MainViewModel(universe);

            Assert.IsNotNull(vm.ListPlanetsViewModel);
            Assert.IsNotNull(vm.ListPropertiesViewModel);
            Assert.IsNotNull(vm.PlanetDescriptionViewModel);
        }
    }
}
