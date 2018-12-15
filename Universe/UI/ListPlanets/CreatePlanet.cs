using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Universe.Model;

namespace Universe.UI.ListPlanets
{
    public sealed class CreatePlanet : ICommand
    {
        private readonly AsyncPlanets _planets;

        public CreatePlanet(AsyncPlanets planets)
        {
            _planets = planets;
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
                await _planets.CreateAsync(name);
            }
        }
#pragma warning disable 0067
        public event EventHandler CanExecuteChanged;
    }
}