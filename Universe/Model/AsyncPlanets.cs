using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Universe.Model
{
    public sealed class AsyncPlanets : IPlanets
    {
        private readonly IPlanets _inner;

        public AsyncPlanets(IPlanets inner)
        {
            _inner = inner;
        }

        public IEnumerator<IPlanet> GetEnumerator()
        {
            return _inner.GetEnumerator();
        }

        public IPlanet Create(string name)
        {
            var planet = _inner.Create(name);
            NewPlanetEvent?.Invoke(this, new NewPlanetEventArgs(planet));
            return planet;
        }

        public async Task<IPlanet> CreateAsync(string name)
        {
            var planet = await Task.Run(() => _inner.Create(name));
            NewPlanetEvent?.Invoke(this, new NewPlanetEventArgs(planet));
            return planet;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public event EventHandler<NewPlanetEventArgs> NewPlanetEvent;
    }
}