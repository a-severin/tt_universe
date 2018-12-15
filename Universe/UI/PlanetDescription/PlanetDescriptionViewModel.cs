using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Universe.Model;

namespace Universe.UI.PlanetDescription
{
    public sealed class PlanetDescriptionViewModel : ObservableObject
    {
        private readonly IUniverse _universe;
        private IPlanet _planet;
        private PropertyPresenter _selectedAvailableProperty;

        public PlanetDescriptionViewModel(IUniverse universe)
        {
            _universe = universe;
            AddProperty = new RelayCommand(_addProperty, () => SelectedAvailableProperty != null);
        }

        private void _addProperty()
        {
            _planet.Properties().Add(SelectedAvailableProperty.Property);
            PlanetProperties.Add(new PropertyPresenter(SelectedAvailableProperty.Property));
            AvailableToAddProperties.Remove(SelectedAvailableProperty);
        }

        public ObservableCollection<PropertyPresenter> AvailableToAddProperties { get; } =
            new ObservableCollection<PropertyPresenter>();

        public PropertyPresenter SelectedAvailableProperty
        {
            get => _selectedAvailableProperty;
            set => Set(ref _selectedAvailableProperty, value);
        }

        public ObservableCollection<PropertyPresenter> PlanetProperties { get; } =
            new ObservableCollection<PropertyPresenter>();

        public void ShowPlanetDescription(object sender, IPlanet planet)
        {
            _planet = planet;
            _loadPlanetProperties();
            _loadAvailableProperties();
        }

        public ICommand AddProperty { get; }

        private void _loadPlanetProperties()
        {
            PlanetProperties.Clear();
            if (_planet == null)
            {
                return;
            }

            var planetProperties = _planet.Properties();
            foreach (var planetProperty in planetProperties)
            {
                PlanetProperties.Add(new PropertyPresenter(planetProperty));
            }
        }

        private void _loadAvailableProperties()
        {
            AvailableToAddProperties.Clear();
            if (_planet == null)
            {
                return;
            }

            var planetProperties = _planet.Properties();
            foreach (var property in _universe.Properties().Where(_ => !planetProperties.Contains(_)))
            {
                AvailableToAddProperties.Add(new PropertyPresenter(property));
            }
        }
    }
}