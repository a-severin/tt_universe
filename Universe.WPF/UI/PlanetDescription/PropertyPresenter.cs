using Universe.Model;

namespace Universe.WPF.UI.PlanetDescription
{
    public sealed class PropertyPresenter
    {
        public IProperty Property { get; }

        public PropertyPresenter(IProperty property)
        {
            Property = property;
            
        }

        public string Text => Property.Value();

        public override string ToString()
        {
            return Text;
        }
    }
}