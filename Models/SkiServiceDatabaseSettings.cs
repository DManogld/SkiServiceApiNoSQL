namespace SkiServiceApi.Models;

public class SkiServiceDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string SkiServiceCollectionName { get; set; } = null!;
}
