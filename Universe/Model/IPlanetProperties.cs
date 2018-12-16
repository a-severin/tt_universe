using System.Collections.Generic;

namespace Universe.Model
{
    public interface IPlanetProperties: IEnumerable<IPlanetProperty>
    {
        IPlanetProperty Add(IProperty property);
        bool Contains(IProperty property);
    }
}