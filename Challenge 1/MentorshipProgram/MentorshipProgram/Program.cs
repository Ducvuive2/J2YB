using System.Configuration;

namespace DbConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            IDatabaseConnection dbConnection = new DatabaseConnection(connectionString);
            IQueryExecutorService queryExecutorService = new QueryExecutorService(dbConnection);
            queryExecutorService.ExecuteQueriesFromFile("queries.json");
        }
    }
}
