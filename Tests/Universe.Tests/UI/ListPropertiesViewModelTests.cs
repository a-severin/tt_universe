using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Universe.Model;
using Universe.WPF.UI.ListProperties;

namespace Universe.Tests.UI
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ListPropertiesViewModelTests : BaseUniverseTests
    {
        [TestMethod]
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public void Constructor_NotEmptyCollection(UniverseSources source)
        {
            Assert.IsTrue(new ListPropertiesViewModel(
                new TestDataUniverse(Universe(source))
            ).PropertyPresenters.Any());
        }
    }
}