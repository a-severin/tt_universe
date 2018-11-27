using System.Collections.Generic;

namespace Universe.Model
{
    public interface IProperties: IEnumerable<IProperty>
    {
        void Add(IProperty property);
        void Delete(IProperty property);
    }
}