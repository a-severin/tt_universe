using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using Universe.Model;

namespace Universe.UI.ListPlanets
{
    public class ListPlanetsViewModel: ObservableObject
    {
        public ListPlanetsViewModel(IUniverse universe)
        {
            foreach (var planet in universe.Planets())
            {
                PlanetPresenters.Add(new PlanetPresenter(planet));
            }
        }

        public ObservableCollection<PlanetPresenter> PlanetPresenters { get; } = new ObservableCollection<PlanetPresenter>();
    }

    public class PlanetPresenter
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