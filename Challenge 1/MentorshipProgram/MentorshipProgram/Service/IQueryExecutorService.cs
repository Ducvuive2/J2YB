namespace DbConsoleApp
{
    public interface IQueryExecutorService
    {
        bool ExecuteQueriesFromFile(string filePath);
    }
}
