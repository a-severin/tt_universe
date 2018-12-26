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
        public void Create_InvokeEvent()
        {
            var value = "TestPropertyValue";
            var asyncProperties = new AsyncProperties(universe.Properties());
            var eventInvoked = false;
            asyncProperties.NewPropertyEvent += (sender, args) => eventInvoked = true;

            var property = asyncProperties.Create(value);

            Assert.AreEqual(property.Value(), property.Value());
            Assert.IsTrue(eventInvoked);
            Assert.IsTrue(asyncProperties.Any());
        }

        [TestMethod]
        public async Task CreateAsync_InvokeEvent()
        {
            var value = "TestPropertyValue";
            var asyncProperties = new AsyncProperties(universe.Properties());
            var eventInvoked = false;
            asyncProperties.NewPropertyEvent += (sender, args) => eventInvoked = true;

            var property = await asyncProperties.CreateAsync(value);

            Assert.AreEqual(property.Value(), property.Value());
            Assert.IsTrue(eventInvoked);
            Assert.IsTrue(asyncProperties.Any());
        }

        [TestMethod]
        public void Properties_Empty_AfterDelete()
        {
            var asyncProperties = new AsyncProperties(universe.Properties());
            asyncProperties.Create("Test Property");
            asyncProperties.First().Delete();
            Assert.IsFalse(asyncProperties.Any());
        }

        [TestMethod]
        public void Properties_NotEmpty_AfterCreateOne()
        {
            var asyncProperties = new AsyncProperties(universe.Properties());
            asyncProperties.Create("Test Property");
            Assert.IsTrue(asyncProperties.Any());
        }
    }
}