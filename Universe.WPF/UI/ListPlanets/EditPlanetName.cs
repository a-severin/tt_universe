using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Universe.Model;

namespace Universe.WPF.UI.ListPlanets
{
    public sealed class EditPlanetName : ICommand
    {
        private readonly AsyncPlanet _planet;

        public EditPlanetName(AsyncPlanet planet)
        {
            _planet = planet;
        }

        public bool CanExecute(object parameter)
        {
            if (parameter is string name)
            {
                return !string.IsNullOrEmpty(name);
            }

            return false;
        }

        public async void Execute(object parameter)
        {
            await ExecuteAsync(parameter);
        }

        public async Task ExecuteAsync(object parameter)
        {
            if (parameter is string name)
            {
                await _planet.RenameAsync(name);
            }
        }

#pragma warning disable 0067
        public event EventHandler CanExecuteChanged;
    }
}