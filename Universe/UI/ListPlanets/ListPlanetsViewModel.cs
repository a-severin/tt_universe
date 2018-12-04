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
}