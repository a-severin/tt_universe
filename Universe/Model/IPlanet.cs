using System.Collections.Generic;

namespace Universe.Model
{
    public interface IPlanet
    {
        string Name();
        void Rename(string name);
        IPlanetProperties Properties();
        void Delete();
        
    }

    public interface IPlanetProperties: IEnumerable<IProperty>
    {
        void Add(IProperty property);
        bool Contains(IProperty property);
    }
}