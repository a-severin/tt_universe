using System;

namespace Universe.Model.InMemory
{
    internal sealed class Property : IProperty
    {
        private string _value;
        private readonly Action<Property> _delete;

        public Property(string value, Action<Property> delete)
        {
            _value = value;
            _delete = delete;
        }

        public string Value()
        {
            return _value;
        }

        public void Change(string value)
        {
            _value = value;
        }

        public void Delete()
        {
            _delete(this);
        }
    }
}