using DbConsoleApp;
using System.Collections.Generic;
using System.Data.SqlClient;

public class DatabaseConnection : IDatabaseConnection
{
    private string _connectionString;

    public DatabaseConnection(string connectionString)
    {
        _connectionString = connectionString;
    }
    public int ExecuteNonQuery(string connectionString, string query)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            var command = new SqlCommand(query, connection);
            connection.Open();
            return command.ExecuteNonQuery();
        }
    }
    public List<Product> GetProducts(string query)
    {
        List<Product> products = new List<Product>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Price = reader.GetDecimal(reader.GetOrdinal("Price"))
                    });
                }
            }
        }

        return products;
    }
}
