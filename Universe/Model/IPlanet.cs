using System.Collections.Generic;

namespace Universe.Model
{
    public interface IPlanet
    {
        string Name();
        void Rename(string name);
        IEnumerable<IProperty> Properties();
        void Add(IProperty property);
        void Delete(IProperty property);
    }
}