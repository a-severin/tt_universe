using Universe.Model;

namespace Universe.UI.ListPlanets
{
    public sealed class PlanetPresenter
    {
        private readonly IPlanet _planet;

        public PlanetPresenter(IPlanet planet)
        {
            _planet = planet;
        }

        public string Text
        {
            get => _planet.Name();
            
        }
    }
}