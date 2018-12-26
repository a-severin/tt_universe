using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Universe.Model;

namespace Universe.WPF.UI.ListProperties
{
    public class EditPropertyValue : ICommand
    {
        private readonly AsyncProperty _property;

        public EditPropertyValue(AsyncProperty property)
        {
            _property = property;
        }

        public bool CanExecute(object parameter)
        {
            if (parameter is string value)
            {
                return !string.IsNullOrEmpty(value);
            }

            return false;
        }

        public async void Execute(object parameter)
        {
            await ExecuteAsync(parameter);
        }

        public async Task ExecuteAsync(object parameter)
        {
            if (parameter is string value)
            {
                await _property.ChangeAsync(value);
            }
        }

#pragma warning disable 0067
        public event EventHandler CanExecuteChanged;
    }
}