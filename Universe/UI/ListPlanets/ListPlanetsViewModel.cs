﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Universe.Model;

namespace Universe.UI.ListPlanets
{
    public sealed class ListPlanetsViewModel : ObservableObject
    {
        private readonly AsyncPlanets _planets;

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
            var asyncPlanet = new AsyncPlanet(planet);
            var planetPresenter = new PlanetPresenter(asyncPlanet);
            PlanetPresenters.Add(planetPresenter);
            asyncPlanet.PlanetDeleted += (sender, args) => { PlanetPresenters.Remove(planetPresenter); };
        }
    }
}