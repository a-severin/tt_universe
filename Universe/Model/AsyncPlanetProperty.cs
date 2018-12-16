using System;
using System.Threading.Tasks;

namespace Universe.Model
{
    public sealed class AsyncPlanetProperty : IPlanetProperty
    {
        private readonly IPlanetProperty _inner;

        public AsyncPlanetProperty(IPlanetProperty inner)
        {
            _inner = inner;
        }

        public string Value()
        {
            return _inner.Value();
        }

        public void Delete()
        {
            _inner.Delete();
            Deleted?.Invoke(this, EventArgs.Empty);
        }

        public async Task DeleteAsync()
        {
            await Task.Run(() => _inner.Delete());
            Deleted?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler Deleted;
    }
}