using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Universe.Model;

namespace Universe.UI.ListPlanets
{
    public sealed class ListPlanetsViewModel : ObservableObject
    {
        private readonly AsyncPlanets _planets;
        private PlanetPresenter _selectedPlanetPresenter;

        public ListPlanetsViewModel(IUniverse universe)
        {
            _planets = new AsyncPlanets(universe.Planets());
            _planets.NewPlanetEvent += (sender, args) => { _addPlanet(args.Planet); };

            CreatePlanet = new CreatePlanet(_planets);
            ReloadPlanets = new RelayCommand(_loadPlanets);

            _loadPlanets();
        }

        public ObservableCollection<PlanetPresenter> PlanetPresenters { get; } =
            new ObservableCollection<PlanetPresenter>();

        public PlanetPresenter SelectedPlanetPresenter
        {
            get => _selectedPlanetPresenter;
            set
            {
                _selectedPlanetPresenter = value;
                PlanetSelected?.Invoke(this, _selectedPlanetPresenter?.Planet);
            }
        }

        public event EventHandler<IPlanet> PlanetSelected;

        public ICommand CreatePlanet { get; }

        public ICommand ReloadPlanets { get; }

        private void _loadPlanets()
        {
            PlanetPresenters.Clear();
            foreach (var planet in _planets)
            {
                _addPlanet(planet);
            }
        }

        private void _addPlanet(IPlanet planet)
        {
            PlanetPresenters.Add(new PlanetPresenter(new AsyncPlanet(planet),
                presenter => PlanetPresenters.Remove(presenter)));
        }
    }
}