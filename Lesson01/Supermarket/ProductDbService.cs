﻿using System;
using System.Data.SqlClient;

namespace Supermarket
{
    internal class ProductDbService
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

            DataAccessLayer.ExecuteNonQuery(command);
        }

        public void ReadAllProducts()
        {
            string command = "SELECT * FROM dbo.Product;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessLayer.Connection_String))
                {
                    connection.Open();

                    SqlCommand sqlCommand = new SqlCommand(command, connection);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        ReadProductsFromDataReader(reader);
                    }
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
        }

        public void GetProductById(int id)
        {
            string command = "SELECT *" +
                " FROM dbo.Product" +
                $" WHERE Id = {id}";

            SqlConnection connection = new SqlConnection(DataAccessLayer.Connection_String);

            try
            {
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand(command, connection);

                SqlDataReader reader = sqlCommand.ExecuteReader();

                ReadProductsFromDataReader(reader);
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
                connection.Close();
            }
        }

        public void GetProductsByCategoryId(int categoryId)
        {
            string command = "SELECT * " +
                " FROM dbo.Product" +
                $" WHERE Category_Id = {categoryId}";

            SqlConnection connection = new SqlConnection(DataAccessLayer.Connection_String);

            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(command, connection);

                SqlDataReader reader = sqlCommand.ExecuteReader();

                ReadProductsFromDataReader(reader);
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
                connection.Close();
            }
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

class Employee
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public decimal Salary { get; set; }
}

class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
}
