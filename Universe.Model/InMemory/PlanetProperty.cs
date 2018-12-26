using System;

namespace Universe.Model.InMemory
{
    internal sealed class PlanetProperty : IPlanetProperty
    {
        private readonly IProperty _property;
        private readonly Action<PlanetProperty> _delete;

        public PlanetProperty(IProperty property, Action<PlanetProperty> delete)
        {
            _property = property;
            _delete = delete;
        }

        public string Value()
        {
            return _property.Value();
        }

        public void Delete()
        {
            _delete(this);
        }
    }
}