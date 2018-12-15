﻿using System.Windows.Input;
using GalaSoft.MvvmLight;
using Universe.Model;
using Universe.Model.InMemory;

namespace Universe.UI.ListPlanets
{
    public sealed class PlanetPresenter : ObservableObject
    {
        private readonly AsyncPlanet _planet;

        public PlanetPresenter(AsyncPlanet planet)
        {
            _planet = planet;
            EditName = new EditPlanetName(_planet);
            DeleteItem = new DeletePlanet(_planet);
            _planet.PlanetRenamed += (sender, args) => { this.RaisePropertyChanged(nameof(Text)); };
        }

        public string Text => _planet.Name();

        public ICommand DeleteItem { get; }

        public ICommand EditName { get; }
        public IPlanet Planet => _planet;
    }
}