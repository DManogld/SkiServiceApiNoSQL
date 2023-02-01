namespace SkiServiceApi.Models;

/// <summary>
/// Settings für die Datebank Klasse
/// </summary>
public class SkiServiceDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string SkiServiceCollectionNameClient { get; set; } = null!;

    public string SkiServiceCollectionNameMittarbeiter { get; set; } = null!;
}
