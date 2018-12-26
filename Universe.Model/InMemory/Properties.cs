using System.Collections;
using System.Collections.Generic;

namespace Universe.Model.InMemory
{
    internal sealed class Properties : IProperties
    {
        private readonly List<Property> _properties = new List<Property>();

        public IEnumerator<IProperty> GetEnumerator()
        {
            return _properties.GetEnumerator();
        }

        public IProperty Create(string value)
        {
            var property = new Property(value, _ => _properties.Remove(_));
            _properties.Add(property);
            return property;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}