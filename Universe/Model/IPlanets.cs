using System.Collections.Generic;

namespace Universe.Model
{
    public interface IPlanets: IEnumerable<IPlanet>
    {
        void Add(IPlanet planet);
        void Delete(IPlanet planet);
    }
}