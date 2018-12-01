using System;
using System.Collections;
using System.Collections.Generic;

namespace Universe.Model.InMemory
{
    internal sealed class Universe : IUniverse
    {
        private readonly Planets _planets = new Planets();
        private readonly Properties _properties = new Properties();

        public IPlanets Planets()
        {
            return _planets;
        }

        public IProperties Properties()
        {
            return _properties;
        }
    }

    internal sealed class Planets : IPlanets
    {
        private readonly List<Planet> _planets = new List<Planet>();

        public IEnumerator<IPlanet> GetEnumerator()
        {
            return _planets.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IPlanet Create(string name)
        {
            var planet = new Planet(name, _ => _planets.Remove(_));
            _planets.Add(planet);
            return planet;
        }
    }

    internal sealed class Planet : IPlanet
    {
        private readonly Action<Planet> _delete;
        private string _name;

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

        public IEnumerable<IProperty> Properties()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            _delete(this);
        }
    }

    internal sealed class Properties : IProperties
    {
        private readonly List<Property> _properties = new List<Property>();

        public IEnumerator<IProperty> GetEnumerator()
        {
            return _properties.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(IProperty property)
        {
            throw new NotImplementedException();
        }

        public void Delete(IProperty property)
        {
            throw new NotImplementedException();
        }
    }

    internal sealed class Property : IProperty
    {
        public string Value()
        {
            throw new NotImplementedException();
        }

        public void Change(string value)
        {
            throw new NotImplementedException();
        }
    }
}