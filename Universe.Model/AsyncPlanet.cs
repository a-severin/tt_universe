using System;
using System.Threading.Tasks;

namespace Universe.Model
{
    public sealed class AsyncPlanet : IPlanet
    {
        private readonly IPlanet _inner;

        public AsyncPlanet(IPlanet inner)
        {
            _inner = inner;
        }

        public string Name()
        {
            return _inner.Name();
        }

        public void Rename(string name)
        {
            _inner.Rename(name);
            PlanetRenamed?.Invoke(this, EventArgs.Empty);
        }

        public IPlanetProperties Properties()
        {
            return _inner.Properties();
        }

        public void Delete()
        {
            _inner.Delete();
            PlanetDeleted?.Invoke(this, EventArgs.Empty);
        }

        public async Task DeleteAsync()
        {
            await Task.Run(() => _inner.Delete());
            PlanetDeleted?.Invoke(this, EventArgs.Empty);
        }

        public async Task<string> NameAsync()
        {
            return await Task.Run(() => _inner.Name());
        }

        public event EventHandler PlanetDeleted;

        public event EventHandler PlanetRenamed;

        public async Task RenameAsync(string name)
        {
            await Task.Run(() => _inner.Rename(name));
            PlanetRenamed?.Invoke(this, EventArgs.Empty);
        }
    }
}