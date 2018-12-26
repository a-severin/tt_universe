using System.Collections.Generic;

namespace Universe.Model
{
    public interface IProperties: IEnumerable<IProperty>
    {
        IProperty Create(string value);
    }
}