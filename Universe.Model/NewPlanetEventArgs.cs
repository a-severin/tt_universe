using System;
using System.Diagnostics.CodeAnalysis;

namespace Universe.Model
{
    [ExcludeFromCodeCoverage]
    public class NewPlanetEventArgs : EventArgs
    {
        public IPlanet Planet { get; }

        public NewPlanetEventArgs(IPlanet planet)
        {
            Planet = planet;
        }
    }
}