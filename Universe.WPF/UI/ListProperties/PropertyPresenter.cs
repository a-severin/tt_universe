using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Universe.Model;

namespace Universe.WPF.UI.ListProperties
{
    public sealed class PropertyPresenter : ObservableObject
    {
        private readonly AsyncProperty _property;

        public PropertyPresenter(AsyncProperty property, Action<PropertyPresenter> delete)
        {
            _property = property;

            DeleteItem = new DeleteProperty(_property);
            EditName = new EditPropertyValue(_property);

            _property.PropertyChanged += (sender, args) => { RaisePropertyChanged(nameof(Text)); };
            _property.PropertyDeleted += (sender, args) => { delete(this); };
        }

        public string Text
        {
            get => _property.Value();
        }

        public ICommand DeleteItem { get; }

        public ICommand EditName { get; }
    }
}