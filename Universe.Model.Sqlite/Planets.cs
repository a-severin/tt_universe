using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Universe.Model.Sqlite
{
    internal sealed class Planets : IPlanets
    {
        private readonly SQLiteConnection _connection;

        public Planets(SQLiteConnection connection)
        {
            _connection = connection;
        }

        public IEnumerator<IPlanet> GetEnumerator()
        {
            return _load().GetEnumerator();
        }

        private IEnumerable<IPlanet> _load()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select id from planet;";
                var reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    yield break;
                }

                while (reader.Read())
                {
                    yield return new Planet(_connection, reader.GetInt64(0));
                }
            }
        }

        public IPlanet Create(string name)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "insert into planet (name) values (@name);";
                command.Parameters.AddWithValue("@name", name);

                var insertedRows = command.ExecuteNonQuery();
                if (insertedRows == 0)
                {
                    throw new DataException($"Fail to create planet with name <{name}>");
                }

                return new Planet(_connection, _connection.LastInsertRowId);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}