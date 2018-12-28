using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Universe.Model;

namespace Universe.Tests.Model
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class AsyncPropertiesTests : BaseUniverseTests
    {
        [TestMethod]
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public void Create_InvokeEvent(UniverseSources source)
        {
            var value = "TestPropertyValue";
            var asyncProperties = new AsyncProperties(Universe(source).Properties());
            var eventInvoked = false;
            asyncProperties.NewPropertyEvent += (sender, args) => eventInvoked = true;

            var property = asyncProperties.Create(value);

            Assert.AreEqual(value, property.Value());
            Assert.IsTrue(eventInvoked);
            Assert.IsTrue(asyncProperties.Any());
        }

        [TestMethod]
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public async Task CreateAsync_InvokeEvent(UniverseSources source)
        {
            var value = "TestPropertyValue";
            var asyncProperties = new AsyncProperties(Universe(source).Properties());
            var eventInvoked = false;
            asyncProperties.NewPropertyEvent += (sender, args) => eventInvoked = true;

            var property = await asyncProperties.CreateAsync(value);

            Assert.AreEqual(property.Value(), property.Value());
            Assert.IsTrue(eventInvoked);
            Assert.IsTrue(asyncProperties.Any());
        }

        [TestMethod]
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public void Properties_Empty_AfterDelete(UniverseSources source)
        {
            var asyncProperties = new AsyncProperties(Universe(source).Properties());
            asyncProperties.Create("Test Property");
            asyncProperties.First().Delete();
            Assert.IsFalse(asyncProperties.Any());
        }

        [TestMethod]
        [DataRow(UniverseSources.InMemo)]
        [DataRow(UniverseSources.SQLite)]
        public void Properties_NotEmpty_AfterCreateOne(UniverseSources source)
        {
            var asyncProperties = new AsyncProperties(Universe(source).Properties());
            asyncProperties.Create("Test Property");
            Assert.IsTrue(asyncProperties.Any());
        }
    }
}