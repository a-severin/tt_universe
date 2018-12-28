using System;
using System.Data.SQLite;

namespace Universe.Model.Sqlite
{
    internal sealed class Planet : IPlanet
    {
        private readonly SQLiteConnection _connection;
        private readonly long _id;

        public Planet(SQLiteConnection connection, long id)
        {
            _connection = connection;
            _id = id;
        }

        public string Name()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select name from planet where id=@id;";
                command.Parameters.AddWithValue("@id", _id);
                var reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    throw new ApplicationException($"Fail to load planet by id <{_id}>");
                }

                reader.Read();
                return reader.GetString(0);
            }
        }

        public void Rename(string name)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "update planet set name=@name where id=@id;";
                command.Parameters.AddWithValue("@id", _id);
                command.Parameters.AddWithValue("@name", name);

                var updatedRow = command.ExecuteNonQuery();
                if (updatedRow == 0)
                {
                    throw new ApplicationException($"Fail to update plant <{_id}> with name <{name}>");
                }
            }
        }

        public IPlanetProperties Properties()
        {
            return new PlanetProperties(_connection, _id);
        }

        public void Delete()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "delete from planet where id=@id;";
                command.Parameters.AddWithValue("@id", _id);

                var deletedRow = command.ExecuteNonQuery();
                if (deletedRow == 0)
                {
                    throw new ApplicationException($"Fail to delete plant by id <{_id}>");
                }
            }
        }
    }
}