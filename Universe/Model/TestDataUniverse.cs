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