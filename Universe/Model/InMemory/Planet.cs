using System;

namespace Universe.Model.InMemory
{
    internal sealed class Planet : IPlanet
    {
        private readonly Action<Planet> _delete;
        private string _name;
        private PlanetProperties _planetProperties = new PlanetProperties();

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

        public IPlanetProperties Properties()
        {
            return _planetProperties;
        }


        public void Delete()
        {
            _delete(this);
        }
    }
}