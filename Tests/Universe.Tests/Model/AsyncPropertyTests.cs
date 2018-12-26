using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Universe.Model;

namespace Universe.Tests.Model
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class AsyncPropertyTests : BaseUniverseTests
    {
        [TestMethod]
        public void Value_ReturnValuePassedToConstructor()
        {
            var value = "Test";
            var property = new AsyncProperty(universe.Properties().Create(value));

            Assert.AreEqual(value, property.Value());
        }

        [TestMethod]
        public void Delete_RemoveItem()
        {
            var property = new AsyncProperty(universe.Properties().Create(""));

            Assert.IsTrue(universe.Properties().Any());

            property.Delete();

            Assert.IsFalse(universe.Properties().Any());
        }

        [TestMethod]
        public async Task DeleteAsync_InvokePropertyDeleted()
        {
            var property = new AsyncProperty(universe.Properties().Create(""));
            var eventInvoked = false;
            property.PropertyDeleted += (sender, args) => { eventInvoked = true; };

            await property.DeleteAsync();

            Assert.IsTrue(eventInvoked);
            Assert.IsFalse(universe.Properties().Any());
        }

        [TestMethod]
        public void Change_UpdateValue()
        {
            var value = "Test";
            var property = new AsyncProperty(universe.Properties().Create(value));

            value = "Test2";
            property.Change(value);

            Assert.AreEqual(value, property.Value());
        }

        [TestMethod]
        public async Task ChangeAsync_InvokePropertyChanged()
        {
            var property = new AsyncProperty(universe.Properties().Create(""));
            var eventInvoked = false;
            property.PropertyChanged += (sender, args) => { eventInvoked = true; };

            var value = "Test";
            await property.ChangeAsync(value);

            Assert.IsTrue(eventInvoked);
            Assert.AreEqual(value, property.Value());
        }
    }
}