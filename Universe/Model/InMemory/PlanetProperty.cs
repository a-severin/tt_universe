using System;

namespace Universe.Model.InMemory
{
    internal sealed class PlanetProperty : IPlanetProperty
    {
        private readonly string _value;
        private readonly Action<PlanetProperty> _delete;

        public PlanetProperty(string value, Action<PlanetProperty> delete)
        {
            _value = value;
            _delete = delete;
        }

        public string Value()
        {
            return _value;
        }

        public void Delete()
        {
            _delete(this);
        }
    }
}