using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Universe.Model;

namespace Universe.WPF.UI.PlanetDescription
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

        public ICommand AddProperty { get; }

        public ObservableCollection<PropertyPresenter> AvailableToAddProperties { get; } =
            new ObservableCollection<PropertyPresenter>();

        public ObservableCollection<PlanetPropertyPresenter> PlanetProperties { get; } =
            new ObservableCollection<PlanetPropertyPresenter>();

        public PropertyPresenter SelectedAvailableProperty
        {
            get => _selectedAvailableProperty;
            set => Set(ref _selectedAvailableProperty, value);
        }

        private void _addPresenter(IPlanetProperty planetProperty)
        {
            var asyncPlanetProperty = new AsyncPlanetProperty(planetProperty);
            var planetPropertyPresenter = new PlanetPropertyPresenter(asyncPlanetProperty);
            asyncPlanetProperty.Deleted += (sender, args) => { PlanetProperties.Remove(planetPropertyPresenter); };
            PlanetProperties.Add(planetPropertyPresenter);
        }

        private void _addProperty()
        {
            if (_planet == null) return;

            var planetProperty = _planet.Properties().Add(SelectedAvailableProperty.Property);
            _addPresenter(planetProperty);
            AvailableToAddProperties.Remove(SelectedAvailableProperty);
        }

        private void _loadAvailableProperties()
        {
            AvailableToAddProperties.Clear();
            if (_planet == null) return;

            var planetProperties = _planet.Properties();
            foreach (var property in _universe.Properties().Where(_ => !planetProperties.Contains(_)))
                AvailableToAddProperties.Add(new PropertyPresenter(property));
        }

        private void _loadPlanetProperties()
        {
            PlanetProperties.Clear();
            if (_planet == null) return;

            var planetProperties = _planet.Properties();
            foreach (var planetProperty in planetProperties) _addPresenter(planetProperty);
        }

        public void ShowPlanetDescription(object sender, IPlanet planet)
        {
            _planet = planet;
            _loadPlanetProperties();
            _loadAvailableProperties();
        }
    }
}