namespace Universe.Model.InMemory
{
    public sealed class Universe : IUniverse
    {
        private readonly Planets _planets = new Planets();
        private readonly Properties _properties = new Properties();

        public IPlanets Planets()
        {
            return _planets;
        }

        public IProperties Properties()
        {
            return _properties;
        }
    }
}