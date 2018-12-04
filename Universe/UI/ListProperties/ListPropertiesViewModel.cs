using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using Universe.Model;

namespace Universe.UI.ListProperties
{
    public sealed class ListPropertiesViewModel: ObservableObject
    {
        public ListPropertiesViewModel(IUniverse universe)
        {
            foreach (var property in universe.Properties())
            {
                PropertyPresenters.Add(new PropertyPresenter(property));
            }
        }

       public ObservableCollection<PropertyPresenter> PropertyPresenters { get; } = new ObservableCollection<PropertyPresenter>();
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