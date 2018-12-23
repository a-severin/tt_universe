using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Universe.Model;

namespace Universe.UI.ListProperties
{
    public sealed class ListPropertiesViewModel : ObservableObject
    {
        private AsyncProperties _properties;

        public ListPropertiesViewModel(IUniverse universe)
        {
            _properties = new AsyncProperties(universe.Properties());
            _properties.NewPropertyEvent += (sender, args) => _addProperty(args.Property);

            CreateProperty = new CreateProperty(_properties);

            _loadProperties(universe);
        }

        private void _addProperty(IProperty property)
        {
            PropertyPresenters.Add(new PropertyPresenter(property));
        }

        private void _loadProperties(IUniverse universe)
        {
            foreach (var property in _properties)
            {
                _addProperty(property);
            }
        }

        public ObservableCollection<PropertyPresenter> PropertyPresenters { get; } =
            new ObservableCollection<PropertyPresenter>();

        public ICommand CreateProperty { get; }
    }

    public sealed class PropertyPresenter
    {
        private readonly IProperty _property;

        public PropertyPresenter(IProperty property)
        {
            _property = property;
        }

        public string Text
        {
            get => _property.Value();
        }
    }
}