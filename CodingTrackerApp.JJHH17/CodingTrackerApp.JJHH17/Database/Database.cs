using Dapper;
using System.Configuration;
using System.Data.SQLite;

namespace CodingTrackerApp.JJHH17.Database;

public class Database
{
    private static readonly string dbPath = ConfigurationManager.AppSettings["databasePath"];
    private static readonly string tableName = ConfigurationManager.AppSettings["tableName"];
    private static readonly string connectionString = $"Data Source={dbPath};";

    public static void CreateDatabase()
    {
        if (!File.Exists(dbPath))
        {
            SQLiteConnection.CreateFile(dbPath);
            Console.WriteLine("Database created successfully");
        } 
        else
        {
            Console.WriteLine("Database already exists");
        }

        CreateTable();
    }

    private static void CreateTable()
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string tableCreation = @"CREATE TABLE IF NOT EXISTS CodeTracker (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                StartTime TEXT NOT NULL,
                EndTime TEXT NOT NULL,
                Duration TEXT);";

            connection.Execute(tableCreation);
            Console.WriteLine("Table created successfully or already exists");
        }
    }

    public static long AddEntry(string startTime, string endTime, string duration)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            var sql = "INSERT INTO CodeTracker (StartTime, EndTime, Duration) VALUES (@StartTime, @EndTime, @Duration);" +
                $"SELECT last_insert_rowid();";

            var newEntry = new CodingSession(startTime, endTime, duration);

            long newId = connection.ExecuteScalar<long>(sql, newEntry);

            return newId;
        }
    }
}