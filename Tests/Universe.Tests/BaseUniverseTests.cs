using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Universe.Model;

namespace Universe.Tests
{
    [ExcludeFromCodeCoverage]
    public class BaseUniverseTests
    {
        protected IUniverse universe;

        [TestInitialize]
        public void Setup()
        {
            universe = new Universe.Model.InMemory.Universe();
        }
    }
}