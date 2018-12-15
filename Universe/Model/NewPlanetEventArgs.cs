using System;

namespace Universe.Model
{
    public class NewPlanetEventArgs : EventArgs
    {
        public IPlanet Planet { get; }

        public NewPlanetEventArgs(IPlanet planet)
        {
            Planet = planet;
        }
    }
}