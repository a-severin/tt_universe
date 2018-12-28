using System.Data.SQLite;

namespace Universe.Model.Sqlite
{
    public class SqliteUniverse : IUniverse
    {
        private Planets _planets;
        private Properties _properties;

        public SqliteUniverse(SQLiteConnection connection)
        {
            _initSchema(connection);
            _planets = new Planets(connection);
            _properties = new Properties(connection);
        }

        private void _initSchema(SQLiteConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    @"create table if not exists planet(id integer primary key autoincrement, name text);
                      create table if not exists property(id integer primary key autoincrement, value text);
                      create table if not exists planet_property(id integer primary key autoincrement, planet_id integer not null on conflict fail references planet (id) on delete cascade, property_id integer not null on conflict fail references planet (id) on delete cascade);";
                command.ExecuteNonQuery();
            }
        }

        public IPlanets Planets()
        {
            return _planets;
        }

        public IProperties Properties()
        {
            return _properties;
        }
    }
}