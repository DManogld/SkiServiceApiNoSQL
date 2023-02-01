using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SkiServiceApi.Models;

namespace SkiServiceApi.Services
{
    public class StatusService
    {
        private readonly IMongoCollection<Client> _skiServiceCollection;

        public StatusService(IOptions<SkiServiceDatabaseSettings> SkiServiceDatabaseSettings)
        {
            var mongoClient = new MongoClient(SkiServiceDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(SkiServiceDatabaseSettings.Value.DatabaseName);
            _skiServiceCollection = mongoDatabase.GetCollection<Client>(SkiServiceDatabaseSettings.Value.SkiServiceCollectionNameClient);
        }

        public async Task<List<Client>> GetAsync() 
        {
            var sort = Builders<Client>.Sort.Descending("Status");
            return await _skiServiceCollection.Find(_ => true).Sort(sort).ToListAsync();
        } 
    }
}
