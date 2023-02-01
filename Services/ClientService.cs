
using SkiServiceApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace SkiServiceApi.Services;
public class ClientService
{
    private readonly IMongoCollection<Client> _skiServiceCollection;

    /// <summary>
    ///  Client Service Konstruktor mit Dateneinstellungen/-konfiguration
    /// </summary>
    /// <param name="SkiServiceDatabaseSettings"></param>
    public ClientService(IOptions<SkiServiceDatabaseSettings> SkiServiceDatabaseSettings)
    {
        var mongoClient = new MongoClient(SkiServiceDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(SkiServiceDatabaseSettings.Value.DatabaseName);
        _skiServiceCollection = mongoDatabase.GetCollection<Client>(SkiServiceDatabaseSettings.Value.SkiServiceCollectionNameClient);
    }

    /// <summary>
    /// Get Methode welche Client von MongoDB Datenbank abruft 
    /// </summary>
    /// <returns>Liste von Registrationen</returns>
    public async Task<List<Client>> GetAsync() => await _skiServiceCollection.Find(_ => true).ToListAsync();


    /// <summary>
    /// Get Methode welche Client nach id von MongoDB Datenbank abruft
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Client?> GetAsync(string id) => await _skiServiceCollection.Find(x => x._id == id).FirstOrDefaultAsync();

    /// <summary>
    /// Create Methode welche Client in MongoDB Datenbank erstellt
    /// </summary>
    /// <param name="newClient"></param>
    /// <returns></returns>
    public async Task CreateAsync(Client newClient) => await _skiServiceCollection.InsertOneAsync(newClient);

    /// <summary>
    /// Update Methode welche Client in MongoDB Datenbank modifiziert
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updateClient"></param>
    /// <returns></returns>
    public async Task UpdateAsync(string id, Client updateClient) => await _skiServiceCollection.ReplaceOneAsync(x => x._id == id, updateClient);

    /// <summary>
    /// Delete Methode welche Client in MongoDB Datenbank löscht
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task RemoveAsync(string id) => await _skiServiceCollection.DeleteOneAsync(x => x._id == id);
}
