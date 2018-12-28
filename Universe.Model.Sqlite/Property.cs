using System;
using System.Data;
using System.Data.SQLite;

namespace Universe.Model.Sqlite
{
    internal sealed class Property : IProperty
    {
        private readonly SQLiteConnection _connection;
        private readonly long _id;

        public Property(SQLiteConnection connection, long id)
        {
            _connection = connection;
            _id = id;
        }

        public string Value()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select value from property where id=@id;";
                command.Parameters.AddWithValue("@id", _id);
                var reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    throw new DataException($"Fail to load property by id <{_id}>");
                }

                reader.Read();
                return reader.GetString(0);
            }
        }

        public void Change(string value)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "update property set value=@value where id=@id;";
                command.Parameters.AddWithValue("@id", _id);
                command.Parameters.AddWithValue("@value", value);

                var updateRow = command.ExecuteNonQuery();
                if (updateRow == 0)
                {
                    throw new DataException($"Fail to update property <{_id}> with value <{value}>");
                }
            }
        }

        public void Delete()
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "delete from property where id=@id;";
                command.Parameters.AddWithValue("@id", _id);

                var deletedRow = command.ExecuteNonQuery();
                if (deletedRow == 0)
                {
                    throw new DataException($"Fail to delete property by id <{_id}>");
                }
            }
        }
    }
}