using System.Data.SqlClient;
using System;

namespace Supermarket
{
    internal class ProductService
    {
        // CRUD operations
        // Create
        // ReadAll
        // ReadById
        // Update
        // Delete
        // ReadByCategoryId
        // ReadByName
        // ReadByPrice > 500

        public void CreateProduct(string name, decimal price)
        {
            string command = $"INSERT INTO dbo.Product (ProductName, Price) VALUES ('{name}', {price})";

            DAL.ExecuteNonQuery(command);
        }

        public void ReadAllProducts()
        {
            SqlConnection connection = new SqlConnection(
                "Data Source=EPUZTASW0537\\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");

            try
            {
                connection.Open();

                string command = "SELECT * FROM dbo.Product";
                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = command;

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows) // Agarda keyingi qator bo'lsa true aks xolda false
                {
                    // Ustunlarni nomlari
                    Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                    // Keyingi qatorga o'tishga urunib ko'radi
                    // o'ta olsa true aks xolda false
                    while (reader.Read())
                    {
                        object id = reader.GetValue(0);
                        object name = reader.GetValue(1);
                        object price = reader.GetValue(2);

                        Console.WriteLine("{0} \t{1} \t{2}", id, name, price);
                    }
                    Console.WriteLine("Reading finished");
                    reader.Close();

                    Console.WriteLine("Reader disposed.");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong while reading products. {ex.Message}.");
            }
            finally
            {
                Console.WriteLine("Closing connection...");
                connection.Close();
                Console.WriteLine("Connection closed.");
            }

        }

        public void GetProductById(int id)
        {

        }

        public void GetProductsByCategoryId(int categoryId)
        {

        }

        public void UpdateProduct(int id, string newName, decimal newPrice)
        {
            string command = $"UPDATE dbo.Product" +
                    $" SET ProductName = '{newName}', Price = {newPrice}" +
                    $" WHERE Id = {id};";
            DAL.ExecuteNonQuery(command);
        }

        public void DeleteProduct(int id)
        {
            string command = $"DELETE dbo.Product WHERE Id = {id}";
            DAL.ExecuteNonQuery(command);
        }
    }
}
