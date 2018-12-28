using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Universe.WPF.UI.Main;

namespace Universe.Tests.UI.Main
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class MainViewModelTests : BaseUniverseTests
    {
        [TestMethod]
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public void Constructor_Initialize(UniverseSources source)
        {
            var vm = new MainViewModel(Universe(source));

            Assert.IsNotNull(vm.ListPlanetsViewModel);
            Assert.IsNotNull(vm.ListPropertiesViewModel);
            Assert.IsNotNull(vm.PlanetDescriptionViewModel);
        }
    }
}