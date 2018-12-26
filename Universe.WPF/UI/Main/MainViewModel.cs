using GalaSoft.MvvmLight;
using Universe.Model;
using Universe.WPF.UI.ListPlanets;
using Universe.WPF.UI.ListProperties;
using Universe.WPF.UI.PlanetDescription;

namespace Universe.WPF.UI.Main
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