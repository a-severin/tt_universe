using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Universe.Model;
using Universe.WPF.UI.ListProperties;

namespace Universe.Tests.UI.ListProperties
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class PropertyPresenterTests : BaseUniverseTests
    {
        [TestMethod]
        public void Constructor_Initialize()
        {
            var value = "Test";
            var presenter = new PropertyPresenter(new AsyncProperty(universe.Properties().Create(value)),
                propertyPresenter => { });

            Assert.AreEqual(value, presenter.Text);
            Assert.IsNotNull(presenter.DeleteItem);
            Assert.IsNotNull(presenter.EditName);
        }

        [TestMethod]
        public async Task DeleteItem_Execute()
        {
            var command = new DeleteProperty(new AsyncProperty(universe.Properties().Create("")));

            Assert.IsTrue(command.CanExecute(null));

            await command.ExecuteAsync(null);

            Assert.IsFalse(universe.Properties().Any());
        }

        [TestMethod]
        public async Task EditName_Execute()
        {
            var property = new AsyncProperty(universe.Properties().Create(""));
            var command = new EditPropertyValue(property);
            var value = "Test2";

            Assert.IsTrue(command.CanExecute(value));

            await command.ExecuteAsync(value);

            Assert.AreEqual(value, property.Value());
        }
    }
}