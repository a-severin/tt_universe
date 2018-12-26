using System.Collections.Generic;

namespace Universe.Model
{
    public interface IPlanets: IEnumerable<IPlanet>
    {
        IPlanet Create(string name);
    }
}