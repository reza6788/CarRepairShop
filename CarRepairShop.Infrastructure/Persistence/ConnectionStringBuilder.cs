namespace CarRepairShop.Infrastructure.Persistence;

public class ConnectionStringBuilder
{
    private const string ServerAddress = ".";
    private const string DataBaseName = "CarRepairShop";
    private const string Username = "sa";
    private const string Password = "!bU9r5@M";

    private static string BuildMyConnectionString(string serverAddress = "", string dataBaseName = "",
        string userName = "", string password = "")
    {
        var connectionString = $"Server={serverAddress};" +
                               $"Database={dataBaseName};" +
                               $"User Id={userName};" +
                               $"Password={password};" +
                               $"TrustServerCertificate=True";
        return connectionString;
    }

    internal static string GetConnectionStringFromConfiguration()
    {
        return BuildMyConnectionString(ServerAddress, DataBaseName, Username, Password);
    }
}