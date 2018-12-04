namespace Universe.Model
{
    public sealed class TestDataUniverse: IUniverse
    {
        private readonly IUniverse _universe;

        public TestDataUniverse(IUniverse universe)
        {
            _universe = universe;
            var planets = _universe.Planets();
            planets.Create("Mercury");
            planets.Create("Venus");
            planets.Create("Earth");
            planets.Create("Mars");
            planets.Create("Jupiter");
            planets.Create("Saturn");
            planets.Create("Uranus");

            var properties = _universe.Properties();
            properties.Create("Atmosphere");
            properties.Create("Water");
            properties.Create("Solid");
            properties.Create("Radiation");
            properties.Create("Hot");
            properties.Create("Cold");
            properties.Create("Ice");
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