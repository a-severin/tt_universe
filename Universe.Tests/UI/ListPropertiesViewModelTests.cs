using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Universe.Model;
using Universe.UI.ListProperties;

namespace Universe.Tests.UI
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ListPropertiesViewModelTests : BaseUniverseTests
    {
        [TestMethod]
        public void Constructor_NotEmptyCollection()
        {
            Assert.IsTrue(new ListPropertiesViewModel(
                new TestDataUniverse(universe)
            ).PropertyPresenters.Any());
        }
    }
}