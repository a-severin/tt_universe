using System;
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
            if (parameter is string name)
            {
                await _planets.CreateAsync(name);
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}