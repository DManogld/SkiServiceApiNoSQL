using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SkiServiceApi.Models;

namespace SkiServiceApi.Services;
    public class MittarbieterService
    {
        private readonly IMongoCollection<Mitarbeiter> _mittarbeiterCollection;

    /// <summary>
    ///  Mitarbeiter Service Konstruktor mit Dateneinstellungen/-konfiguration
    /// </summary>
    /// <param name="SkiServiceDatabaseSettings"></param>
    public MittarbieterService(IOptions<SkiServiceDatabaseSettings> SkiServiceDatabaseSettings)
    {
        var mongoClient = new MongoClient(SkiServiceDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(SkiServiceDatabaseSettings.Value.DatabaseName);
        _mittarbeiterCollection = mongoDatabase.GetCollection<Mitarbeiter>(SkiServiceDatabaseSettings.Value.SkiServiceCollectionNameMittarbeiter);
    }

    /// <summary>
    /// Get Methode welche Mitarbeiter von MongoDB Datenbank abruft 
    /// </summary>
    /// <returns></returns>
    public async Task<List<Mitarbeiter>> GetAsync() => await _mittarbeiterCollection.Find(_ => true).ToListAsync();
}
