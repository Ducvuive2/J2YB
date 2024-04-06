using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace DbConsoleApp
{
    public class QueryExecutorService : IQueryExecutorService
    {
        private readonly IDatabaseConnection _databaseConnection;
        public QueryExecutorService(IDatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }
        public bool ExecuteQueriesFromFile(string filePath)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            string json = File.ReadAllText(filePath);
            var queries = JObject.Parse(json)["queries"];
            bool success = true;

            foreach (var query in queries)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query["sql"].ToString(), connection);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        success = false;
                    }
                }
            }

            return success;
        }
        public List<Product> FetchProducts()
        {
            var allProducts = _databaseConnection.GetProducts("SELECT * FROM Products");
            return allProducts;
        }
    }
}
