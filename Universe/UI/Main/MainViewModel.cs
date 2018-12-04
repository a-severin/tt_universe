using GalaSoft.MvvmLight;
using Universe.Model;
using Universe.UI.ListPlanets;
using Universe.UI.ListProperties;

namespace Universe.UI.Main
{
    public sealed class MainViewModel: ObservableObject
    {
        public MainViewModel(IUniverse universe)
        {
            ListPlanetsViewModel = new ListPlanetsViewModel(universe);
            ListPropertiesViewModel = new ListPropertiesViewModel(universe);
        }

        public ListPlanetsViewModel ListPlanetsViewModel { get; }
        public ListPropertiesViewModel ListPropertiesViewModel { get; }
    }
}