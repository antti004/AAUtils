using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AAUtilities.Database
{
    public class DbSql
    {
        private string _connectionString;
        public DbSql(string connectionString) =>  _connectionString=connectionString;

        public T GetScalar<T>(string query,Dictionary<string,object> parameters, string connectionString = null)
        {
            object result = default(T);
            using (var conn = new SqlConnection(connectionString??_connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                if (parameters != null)
                {
                    foreach (var pair in parameters)
                        cmd.Parameters.AddWithValue(pair.Key, pair.Value);
                }
                conn.Open();
                result = cmd.ExecuteScalar();
            }

            if ((object.ReferenceEquals(result, DBNull.Value)) || (result == null))
                return default;

            if (object.ReferenceEquals(typeof(T), result.GetType()) || typeof(T).IsAssignableFrom(result.GetType()))
                return (T)result;

            if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Nullable<>))
                return (T)Convert.ChangeType(result, typeof(T).GetGenericArguments()[0]);

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public DataTable GetTable(string query, Dictionary<string, object> parameters, string connectionString = null)
        {
            DataTable data = new DataTable();
            using (var conn = new SqlConnection(connectionString ?? _connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                if (parameters != null)
                {
                    foreach (var pair in parameters)
                        cmd.Parameters.AddWithValue(pair.Key, pair.Value);
                }
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                data.Load(rdr);
                if (!rdr.IsClosed) rdr.Close();
                conn.Close();
            }
            return data;
        }

    }
}
