using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows;

namespace Lesson05.DAL
{
    internal class DataAccessLayer
    {
        public const string Connection_String = "Data Source=LAPTOP-TEN57IC2\\MSSQLSERVER01;Initial Catalog=Company_2;Integrated Security=True";

        public static async Task ExecuteNonQueryAsync(string command)
        {
            ThrowIfNullOrEmpty(command);

            try
            {
                using (SqlConnection connection = new SqlConnection(Connection_String))
                {
                    await connection.OpenAsync();

                    using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                    {
                        int affectedRows = await sqlCommand.ExecuteNonQueryAsync();

                        MessageBox.Show($"Number of affected rows: {affectedRows}");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong: {ex.Message}.");
            }
        }

        public static async Task<T> ExecuteQueryAsync<T>(string command, Func<SqlDataReader, T> converter)
        {
            ThrowIfNullOrEmpty(command);

            try
            {
                using (SqlConnection connection = new SqlConnection(Connection_String))
                {
                    await connection.OpenAsync();

                    using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                    {
                        var dataReader = await sqlCommand.ExecuteReaderAsync();

                        return converter(dataReader);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong: {ex.Message}.");
            }

            return default;
        }

        public static T ExecuteQuery<T>(string command, Func<SqlDataReader, T> converter)
        {
            ThrowIfNullOrEmpty(command);

            try
            {
                using (SqlConnection connection = new SqlConnection(Connection_String))
                {
                    connection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                    {
                        var dataReader = sqlCommand.ExecuteReader();

                        return converter(dataReader);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong: {ex.Message}.");
            }

            return default;
        }

        private static void ThrowIfNullOrEmpty(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException(nameof(str));
            }
        }
    }
}
