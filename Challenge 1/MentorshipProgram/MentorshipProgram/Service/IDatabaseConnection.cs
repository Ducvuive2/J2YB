using System.Collections.Generic;

namespace DbConsoleApp
{
    public interface IDatabaseConnection
    {
        int ExecuteNonQuery(string connectionString, string query);
        List<Product> GetProducts(string query);
    }
}
