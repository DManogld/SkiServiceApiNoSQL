// <snippet_File>
using SkiServiceApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace SkiServiceApi.Services;

public class ClientService
{
    private readonly IMongoCollection<Client> _skiServiceCollection;

    public ClientService(IOptions<SkiServiceDatabaseSettings> SkiServiceDatabaseSettings)
    {
        var mongoClient = new MongoClient(SkiServiceDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(SkiServiceDatabaseSettings.Value.DatabaseName);

        _skiServiceCollection = mongoDatabase.GetCollection<Client>(SkiServiceDatabaseSettings.Value.SkiServiceCollectionName);
    }


    public async Task<List<Client>> GetAsync() => await _skiServiceCollection.Find(_ => true).ToListAsync();

    public async Task<Client?> GetAsync(string id) => await _skiServiceCollection.Find(x => x._id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Client newClient) => await _skiServiceCollection.InsertOneAsync(newClient);

    public async Task UpdateAsync(string id, Client updateClient) => await _skiServiceCollection.ReplaceOneAsync(x => x._id == id, updateClient);

    public async Task RemoveAsync(string id) => await _skiServiceCollection.DeleteOneAsync(x => x._id == id);
}
