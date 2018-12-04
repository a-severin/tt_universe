using System;
using System.Collections.Generic;

namespace Universe.Model.InMemory
{
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
}