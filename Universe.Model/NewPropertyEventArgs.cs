using System;

namespace Universe.Model
{
    public sealed class NewPropertyEventArgs : EventArgs
    {
        public IProperty Property { get; }

        public NewPropertyEventArgs(IProperty property)
        {
            Property = property;
        }
    }
}