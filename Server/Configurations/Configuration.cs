namespace server.configuration;

public class Configuration
{
    public static string GetConnectionString(IConfiguration aConfig)
        {
                var vHost = aConfig["ConnectionString:Host"];
                var vDatabase = aConfig["ConnectionString:Database"];
                var vUsername = aConfig["ConnectionString:Username"];
                var vPassword = aConfig["ConnectionString:Password"];

                return $"Host={vHost};" +
                       $"Database={vDatabase};" +
                       $"Username={vUsername};" +
                       $"Password={vPassword};";
        }
}