using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework07.Models.DataAccesLayer
{
    internal class DAL : IDisposable
    {
        public static readonly string Connection_String = 
            "Data Source=HP-PAVILION-550;Initial Catalog=Company;Integrated Security=True";

        private readonly SqlConnection _connection;

        public DAL()
        {
            _connection = new SqlConnection(Connection_String);
        }

        public T ExecuteQuery<T>(string query, Func<SqlDataReader, T> dataReader)
        {
            ThrowIfNullOrEmpty(query);
            SqlDataReader reader = null;
            
            _connection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(query, _connection))
            {
                reader = sqlCommand.ExecuteReader();
            }

            var result = dataReader(reader);

            _connection.Close();

            return result;
        }

        private static void ThrowIfNullOrEmpty(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException(nameof(str));
            }
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
