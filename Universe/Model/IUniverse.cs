using System;
using System.Threading.Tasks;

namespace Universe.Model
{
    public interface IUniverse
    {
        IPlanets Planets();
        IProperties Properties();
    }
}