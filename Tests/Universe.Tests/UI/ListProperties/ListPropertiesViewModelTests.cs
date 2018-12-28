using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Universe.Model;
using Universe.WPF.UI.ListProperties;

namespace Universe.Tests.UI.ListProperties
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ListPropertiesViewModelTests : BaseUniverseTests
    {
        [TestMethod]
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public void Constructor_Initialize(UniverseSources source)
        {
            var vm = new ListPropertiesViewModel(new TestDataUniverse(Universe(source)));

            Assert.IsTrue(vm.PropertyPresenters.Any());
            Assert.IsNotNull(vm.CreateProperty);
        }
    }
}