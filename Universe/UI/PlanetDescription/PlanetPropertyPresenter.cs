using System.Windows.Input;
using Universe.Model;

namespace Universe.UI.PlanetDescription
{
    public sealed class PlanetPropertyPresenter
    {
        public AsyncPlanetProperty Property { get; }

        public PlanetPropertyPresenter(AsyncPlanetProperty property)
        {
            Property = property;
            DeleteItem = new DeleteItem(property);
        }

        public string Text => Property.Value();

        public override string ToString()
        {
            return Text;
        }

        public ICommand DeleteItem { get; }
    }
}