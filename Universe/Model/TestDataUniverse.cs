namespace Universe.Model
{
    public sealed class TestDataUniverse: IUniverse
    {
        private readonly IUniverse _universe;

        public TestDataUniverse(IUniverse universe)
        {
            _universe = universe;
            var planets = _universe.Planets();
            var mercury = planets.Create("Mercury");
            var venus = planets.Create("Venus");
            var earth = planets.Create("Earth");
            planets.Create("Mars");
            planets.Create("Jupiter");
            planets.Create("Saturn");
            planets.Create("Uranus");

            var properties = _universe.Properties();
            var atmosphere = properties.Create("Atmosphere");
            var water = properties.Create("Water");
            var solid = properties.Create("Solid");
            var radiation = properties.Create("Radiation");
            var hot = properties.Create("Hot");
            var cold = properties.Create("Cold");
            var ice = properties.Create("Ice");

            earth.Properties().Add(atmosphere);
            earth.Properties().Add(water);

            venus.Properties().Add(hot);
            venus.Properties().Add(radiation);

            mercury.Properties().Add(solid);
            mercury.Properties().Add(ice);
            mercury.Properties().Add(cold);
        }

        public IPlanets Planets()
        {
            return _universe.Planets();
        }

        public IProperties Properties()
        {
            return _universe.Properties();
        }
    }
}