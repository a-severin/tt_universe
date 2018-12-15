using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Universe.Model;

namespace Universe.UI.ListPlanets
{
    public sealed class ListPlanetsViewModel: ObservableObject
    {
        public ListPlanetsViewModel(IUniverse universe)
        {
            var planets = new AsyncPlanets(universe.Planets());
            foreach (var planet in planets)
            {
                PlanetPresenters.Add(new PlanetPresenter(planet));
            }

            planets.NewPlanetEvent += (sender, args) =>
            {
                PlanetPresenters.Add(new PlanetPresenter(args.Planet));
            };

            CreatePlanet = new CreatePlanet(planets);
        }

        public ObservableCollection<PlanetPresenter> PlanetPresenters { get; } = new ObservableCollection<PlanetPresenter>();

        public ICommand CreatePlanet { get; }
    }
}