namespace Universe.Model
{
    public interface IPlanet
    {
        string Name();
        void Rename(string name);
        IPlanetProperties Properties();
        void Delete();
        
    }
}