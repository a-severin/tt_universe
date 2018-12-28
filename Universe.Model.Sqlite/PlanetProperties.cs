using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Universe.Model.Sqlite
{
    internal sealed class PlanetProperties : IPlanetProperties
    {
        private readonly SQLiteConnection _connection;
        private readonly long _planetId;

        public PlanetProperties(SQLiteConnection connection, long planetId)
        {
            _connection = connection;
            _planetId = planetId;
        }

        public IEnumerator<IPlanetProperty> GetEnumerator()
        {
            return _load().GetEnumerator();
        }

        private IEnumerable<IPlanetProperty> _load()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select id, property_id from planet_property where planet_id=@planet_id;";
                command.Parameters.AddWithValue("@planet_id", _planetId);

                var reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    yield break;
                }

                while (reader.Read())
                {
                    yield return new PlanetProperty(_connection, reader.GetInt64(0), reader.GetInt64(1));
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IPlanetProperty Add(IProperty property)
        {
            var value = property.Value();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select id from property where value=@value";
                command.Parameters.AddWithValue("@value", value);

                long propertyId;
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        throw new ApplicationException($"Fail add link from planet <{_planetId}> to property with value <{value}>");
                    }

                    reader.Read();
                    propertyId = reader.GetInt64(0);
                }


                command.Parameters.Clear();

                command.CommandText =
                    "insert into planet_property (planet_id, property_id) values (@planet_id, @property_id);";
                command.Parameters.AddWithValue("@planet_id", _planetId);
                command.Parameters.AddWithValue("@property_id", propertyId);

                var insertedRows = command.ExecuteNonQuery();
                if (insertedRows == 0)
                {
                    throw new ApplicationException($"Fail add link from planet <{_planetId}> to property with value <{value}>");
                }

                return new PlanetProperty(_connection, _connection.LastInsertRowId, propertyId);
            }
        }

        public bool Contains(IProperty property)
        {
            var value = property.Value();

            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select id from property where value=@value";
                command.Parameters.AddWithValue("@value", value);

                long propertyId;
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        throw new ApplicationException($"Fail to find property with value <{value}>");
                    }

                    reader.Read();
                    propertyId = reader.GetInt64(0);
                }

                command.Parameters.Clear();
                command.CommandText = "select count(*) from planet_property where planet_id=@planet_id and property_id=@property_id;";
                command.Parameters.AddWithValue("@planet_id", _planetId);
                command.Parameters.AddWithValue("@property_id", propertyId);

                var count = (long)command.ExecuteScalar();

                return count > 0;
            }
        }
    }
}