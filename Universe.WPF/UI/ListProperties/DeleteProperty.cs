using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Universe.Model;

namespace Universe.UI.ListProperties
{
    public class DeleteProperty: ICommand
    {
        private readonly AsyncProperty _property;

        public DeleteProperty(AsyncProperty property)
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

#pragma warning disable 0067
        public event EventHandler CanExecuteChanged;
    }
}