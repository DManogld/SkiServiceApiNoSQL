using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SkiServiceApi.Models;

namespace SkiServiceApi.Services
{
    public class StatusService
    {
        private readonly IMongoCollection<Client> _skiServiceCollection;

        /// <summary>
        /// Status Service Konstruktor mit Dateneinstellungen/-konfiguration
        /// </summary>
        /// <param name="SkiServiceDatabaseSettings"></param>
        public StatusService(IOptions<SkiServiceDatabaseSettings> SkiServiceDatabaseSettings)
        {
            var mongoClient = new MongoClient(SkiServiceDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(SkiServiceDatabaseSettings.Value.DatabaseName);
            _skiServiceCollection = mongoDatabase.GetCollection<Client>(SkiServiceDatabaseSettings.Value.SkiServiceCollectionNameClient);
        }

        /// <summary>
        /// Get Methode welche Client von MongoDB Datenbank nach Status gefiltert abruft
        /// </summary>
        /// <returns></returns>
        public async Task<List<Client>> GetAsync() 
        {
            var sort = Builders<Client>.Sort.Descending("Status");
            return await _skiServiceCollection.Find(_ => true).Sort(sort).ToListAsync();
        } 
    }
}
