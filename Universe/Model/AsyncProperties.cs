using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Universe.Model
{
    public sealed class AsyncProperties : IProperties
    {
        private readonly IProperties _inner;

        public AsyncProperties(IProperties inner)
        {
            _inner = inner;
        }

        public IEnumerator<IProperty> GetEnumerator()
        {
            return _inner.GetEnumerator();
        }

        public async Task<IProperty> CreateAsync(string value)
        {
            var property = await Task.Run(() => _inner.Create(value));
            NewPropertyEvent?.Invoke(this, new NewPropertyEventArgs(property));
            return property;
        }

        public IProperty Create(string value)
        {
            var property = _inner.Create(value);
            NewPropertyEvent?.Invoke(this, new NewPropertyEventArgs(property));
            return property;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public event EventHandler<NewPropertyEventArgs> NewPropertyEvent;
    }
}