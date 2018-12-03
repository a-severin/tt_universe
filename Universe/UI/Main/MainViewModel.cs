using GalaSoft.MvvmLight;
using Universe.Model;
using Universe.UI.ListPlanets;

namespace Universe
{
    public sealed class MainViewModel: ObservableObject
    {
        public MainViewModel(IUniverse universe)
        {
            ListPlanetsViewModel = new ListPlanetsViewModel(universe);
//            RaisePropertyChanged(nameof(ListPlanetsViewModel));
        }

        public ListPlanetsViewModel ListPlanetsViewModel { get; }
    }
}