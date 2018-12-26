using GalaSoft.MvvmLight;
using Universe.Model;
using Universe.UI.ListPlanets;
using Universe.UI.ListProperties;
using Universe.UI.PlanetDescription;

namespace Universe.UI.Main
{
    public sealed class MainViewModel: ObservableObject
    {
        public MainViewModel(IUniverse universe)
        {
            ListPlanetsViewModel = new ListPlanetsViewModel(universe);
            ListPropertiesViewModel = new ListPropertiesViewModel(universe);
            PlanetDescriptionViewModel = new PlanetDescriptionViewModel(universe);

            ListPlanetsViewModel.PlanetSelected += PlanetDescriptionViewModel.ShowPlanetDescription;
        }

        public ListPlanetsViewModel ListPlanetsViewModel { get; }
        public ListPropertiesViewModel ListPropertiesViewModel { get; }
        public PlanetDescriptionViewModel PlanetDescriptionViewModel { get; }
    }
}