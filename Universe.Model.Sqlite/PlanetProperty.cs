using System;
using System.Data;
using System.Data.SQLite;

namespace Universe.Model.Sqlite
{
    internal sealed class PlanetProperty : IPlanetProperty
    {
        private readonly SQLiteConnection _connection;
        private readonly long _id;
        private readonly long _propertyId;

        public PlanetProperty(SQLiteConnection connection, long id, long propertyId)
        {
            _connection = connection;
            _id = id;
            _propertyId = propertyId;
        }

        public string Value()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select value from property where id=@id;";
                command.Parameters.AddWithValue("@id", _propertyId);
                var reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    throw new DataException($"Fail to load property by id <{_id}>");
                }

                reader.Read();
                return reader.GetString(0);
            }
        }

        public void Delete()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "delete from planet_property where id=@id;";
                command.Parameters.AddWithValue("@id", _id);

                var deletedRow = command.ExecuteNonQuery();
                if (deletedRow == 0)
                {
                    throw new DataException($"Fail to delete planet_property by id <{_id}>");
                }
            }
        }
    }
}