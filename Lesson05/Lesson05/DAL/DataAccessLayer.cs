using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows;

namespace Lesson05.DAL
{
    internal class DataAccessLayer : IDisposable
    {
        public const string Connection_String = "Data Source=EPUZTASW0537\\SQLEXPRESS;Initial Catalog=Company;Integrated Security=True";

        private readonly SqlConnection _connection;

        public DataAccessLayer()
        {
            _connection = new SqlConnection(Connection_String);
        }

        public async Task ExecuteNonQueryAsync(string command)
        {
            ThrowIfNullOrEmpty(command);

            await _connection.OpenAsync();

            using (SqlCommand sqlCommand = new SqlCommand(command, _connection))
            {
                int affectedRows = await sqlCommand.ExecuteNonQueryAsync();

                MessageBox.Show($"Number of affected rows: {affectedRows}");
            }
        }

        public async Task<T> ExecuteQueryAsync<T>(string command, Func<SqlDataReader, T> converter)
        {
            ThrowIfNullOrEmpty(command);

            await _connection.OpenAsync();

            using SqlCommand sqlCommand = new SqlCommand(command, _connection);
            var dataReader = await sqlCommand.ExecuteReaderAsync();

            var result = converter(dataReader);

            await _connection.CloseAsync();

            return result;
        }

        public T ExecuteQuery<T>(string command, Func<SqlDataReader, T> converter)
        {
            ThrowIfNullOrEmpty(command);

            _connection.Open();

            using SqlCommand sqlCommand = new SqlCommand(command, _connection);
            var dataReader = sqlCommand.ExecuteReader();

            var result = converter(dataReader);

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
