using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Universe.Model;

namespace Universe.UI.PlanetDescription
{
    public sealed class DeleteItem : ICommand
    {
        private readonly AsyncPlanetProperty _property;

        public DeleteItem(AsyncPlanetProperty property)
        {
            _property = property;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            await ExecuteAsync(parameter);
        }

        public async Task ExecuteAsync(object parameter)
        {
            await _property.DeleteAsync();
        }

        public event EventHandler CanExecuteChanged;
    }
}