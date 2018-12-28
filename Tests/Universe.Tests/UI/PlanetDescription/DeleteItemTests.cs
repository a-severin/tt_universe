using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Universe.Model;
using Universe.WPF.UI.PlanetDescription;

namespace Universe.Tests.UI.PlanetDescription
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DeleteItemTests : BaseUniverseTests
    {
        [TestMethod]
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public async Task Execute_CallDelete(UniverseSources source)
        {
            var dataUniverse = new TestDataUniverse(Universe(source));

            var asyncPlanetProperty = new AsyncPlanetProperty(dataUniverse.Planets().First().Properties().First());
            var deleteItem = new DeleteItem(asyncPlanetProperty);
            var invoked = false;
            asyncPlanetProperty.Deleted += (sender, args) => invoked = true;

            await deleteItem.ExecuteAsync(null);

            Assert.IsTrue(invoked);
        }
    }
}