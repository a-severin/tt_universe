namespace Universe.Model
{
    public interface IProperty
    {
        string Value();
        void Change(string value);
        void Delete();
    }
}