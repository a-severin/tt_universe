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
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public void Value_ReturnValuePassedToConstructor(UniverseSources source)
        {
            var value = "Test";
            var property = new AsyncProperty(Universe(source).Properties().Create(value));

            Assert.AreEqual(value, property.Value());
        }

        [TestMethod]
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public void Delete_RemoveItem(UniverseSources source)
        {
            var universe = Universe(source);
            var property = new AsyncProperty(universe.Properties().Create(""));

            Assert.IsTrue(universe.Properties().Any());

            property.Delete();

            Assert.IsFalse(universe.Properties().Any());
        }

        [TestMethod]
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public async Task DeleteAsync_InvokePropertyDeleted(UniverseSources source)
        {
            var universe = Universe(source);
            var property = new AsyncProperty(universe.Properties().Create(""));
            var eventInvoked = false;
            property.PropertyDeleted += (sender, args) => { eventInvoked = true; };

            await property.DeleteAsync();

            Assert.IsTrue(eventInvoked);
            Assert.IsFalse(universe.Properties().Any());
        }

        [TestMethod]
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public void Change_UpdateValue(UniverseSources source)
        {
            var value = "Test";
            var property = new AsyncProperty(Universe(source).Properties().Create(value));

            value = "Test2";
            property.Change(value);

            Assert.AreEqual(value, property.Value());
        }

        [TestMethod]
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public async Task ChangeAsync_InvokePropertyChanged(UniverseSources source)
        {
            var property = new AsyncProperty(Universe(source).Properties().Create(""));
            var eventInvoked = false;
            property.PropertyChanged += (sender, args) => { eventInvoked = true; };

            var value = "Test";
            await property.ChangeAsync(value);

            Assert.IsTrue(eventInvoked);
            Assert.AreEqual(value, property.Value());
        }
    }
}