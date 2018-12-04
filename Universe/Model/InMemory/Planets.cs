using System.Collections;
using System.Collections.Generic;

namespace Universe.Model.InMemory
{
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
}