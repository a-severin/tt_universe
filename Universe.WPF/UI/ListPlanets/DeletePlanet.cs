using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Universe.Model;

namespace Universe.UI.ListPlanets
{
    public sealed class DeletePlanet : ICommand
    {
        private readonly AsyncPlanet _planet;

        public DeletePlanet(AsyncPlanet planet)
        {
            _planet = planet;
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
            await _planet.DeleteAsync();
        }

#pragma warning disable 0067
        public event EventHandler CanExecuteChanged;
    }
}