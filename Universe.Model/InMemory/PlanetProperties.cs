using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Universe.Model.InMemory
{
    internal sealed class PlanetProperties : IPlanetProperties
    {
        private readonly List<IPlanetProperty> _properties = new List<IPlanetProperty>();

        public IEnumerator<IPlanetProperty> GetEnumerator()
        {
            return _properties.GetEnumerator();
        }

        public IPlanetProperty Add(IProperty property)
        {
            var planetProperty = new PlanetProperty(property, _ => _properties.Remove(_));
            _properties.Add(planetProperty);
            return planetProperty;
        }

        public bool Contains(IProperty property)
        {
            var value = property.Value();
            return _properties.Any(_ => _.Value().Equals(value, StringComparison.CurrentCulture));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}