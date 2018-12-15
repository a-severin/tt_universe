using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Universe.Model.InMemory
{
    internal sealed class Planet : IPlanet
    {
        private readonly Action<Planet> _delete;
        private string _name;
        private PlanetProperties _planetProperties = new PlanetProperties();

        public Planet(string name, Action<Planet> delete)
        {
            _name = name;
            _delete = delete;
        }

        public string Name()
        {
            return _name;
        }

        public void Rename(string name)
        {
            _name = name;
        }

        public IPlanetProperties Properties()
        {
            return _planetProperties;
        }


        public void Delete()
        {
            _delete(this);
        }
    }

    internal sealed class PlanetProperties : IPlanetProperties{

        private List<IProperty> _properties = new List<IProperty>();

        public IEnumerator<IProperty> GetEnumerator()
        {
            return _properties.GetEnumerator();
        }

        public void Add(IProperty property)
        {
            _properties.Add(property);
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