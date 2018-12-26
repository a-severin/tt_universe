using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Universe.Model;

namespace Universe.WPF.UI.ListProperties
{
    public sealed class CreateProperty : ICommand
    {
        private readonly AsyncProperties _properties;

        public CreateProperty(AsyncProperties properties)
        {
            _properties = properties;
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
                await _properties.CreateAsync(value);
            }
        }


#pragma warning disable 0067
        public event EventHandler CanExecuteChanged;
    }
}