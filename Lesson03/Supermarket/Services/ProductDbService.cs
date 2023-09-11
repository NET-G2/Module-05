using System;
using System.Data.SqlClient;

namespace Supermarket
{
    internal class ProductDbService
    {
        public void CreateProduct(string name, decimal price)
        {
            string command = $"INSERT INTO dbo.Product (ProductName, Price) VALUES ('{name}', {price})";

            DataAccessLayer.ExecuteNonQuery(command);
        }

        public void UpdateProduct(int id, string newName, decimal newPrice)
        {
            string command = $"UPDATE dbo.Product" +
                    $" SET ProductName = '{newName}', Price = {newPrice}" +
                    $" WHERE Id = {id};";
            DataAccessLayer.ExecuteNonQuery(command);
        }

        public void DeleteProduct(int id)
        {
            string command = $"DELETE dbo.Product WHERE Id = {id}";
            DataAccessLayer.ExecuteNonQuery(command);
        }

        public void GetAllProducts()
        {
            string command = "SELECT * FROM dbo.Product;";

            DataAccessLayer.ExecuteQuery(command, ReadProductsFromDataReader);
        }

        public void GetProductById(int id)
        {
            string command = "SELECT *" +
                " FROM dbo.Product" +
                $" WHERE Id = {id}";

            DataAccessLayer.ExecuteQuery(command, ReadProductsFromDataReader);
        }

        public void GetProductsByCategoryId(int categoryId)
        {
            string command = "SELECT * " +
                " FROM dbo.Product" +
                $" WHERE Category_Id = {categoryId}";

            DataAccessLayer.ExecuteQuery(command, ReadProductsFromDataReader);
        }

        private static void ReadProductsFromDataReader(SqlDataReader reader)
        {
            if (reader is null)
            {
                return;
            }

            if (reader.HasRows)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}",
                    reader.GetName(0),
                    reader.GetName(1),
                    reader.GetName(2),
                    reader.GetName(3));

                while (reader.Read())
                {
                    object id = reader.GetValue(0);
                    object name = reader.GetValue(1);
                    object price = reader.GetValue(2);
                    object categoryId = reader.GetValue(3);

                    Console.WriteLine("{0} \t{1} \t{2} \t{3}", id, name, price, categoryId);
                }
                reader.Close();
            }
        }
    }
}
