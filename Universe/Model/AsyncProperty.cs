using System;
using System.Threading.Tasks;

namespace Universe.Model
{
    public sealed class AsyncProperty : IProperty
    {
        private readonly IProperty _inner;

        public AsyncProperty(IProperty inner)
        {
            _inner = inner;
        }

        public string Value()
        {
            return _inner.Value();
        }

        public void Change(string value)
        {
            _inner.Change(value);
            PropertyChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Delete()
        {
            _inner.Delete();
            PropertyDeleted?.Invoke(this, EventArgs.Empty);
        }

        public async Task ChangeAsync(string value)
        {
            await Task.Run(() => _inner.Change(value));
            PropertyChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler PropertyChanged;

        public async Task DeleteAsync()
        {
            await Task.Run(() => _inner.Delete());
            PropertyDeleted?.Invoke(this, EventArgs.Empty);
            
        }

        public event EventHandler PropertyDeleted;
    }
}