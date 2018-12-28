using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Universe.Model.Sqlite
{
    internal sealed class Properties : IProperties
    {
        private readonly SQLiteConnection _connection;

        public Properties(SQLiteConnection connection)
        {
            _connection = connection;
        }

        public IEnumerator<IProperty> GetEnumerator()
        {
            return _load().GetEnumerator();
        }

        private IEnumerable<IProperty> _load()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select id from property;";
                var reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    yield break;
                }

                while (reader.Read())
                {
                    yield return new Property(_connection, reader.GetInt64(0));
                }
            }
        }

        public IProperty Create(string value)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "insert into property (value) values (@value);";
                command.Parameters.AddWithValue("@value", value);

                var insertedRows = command.ExecuteNonQuery();
                if (insertedRows == 0)
                {
                    throw new DataException($"Fail to create property with value <{value}>");
                }

                return new Property(_connection, _connection.LastInsertRowId);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}