using System;
using System.Windows.Input;
using Universe.Model;

namespace Universe.UI.ListPlanets
{
    public sealed class EditPlanetName : ICommand
    {
        private readonly IPlanet _planet;

        public EditPlanetName(IPlanet planet)
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

        public void Execute(object parameter)
        {
            if (parameter is string name)
            {
                _planet.Rename(name);
            }
        }

#pragma warning disable 0067
        public event EventHandler CanExecuteChanged;
    }
}