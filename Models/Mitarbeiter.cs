using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace SkiServiceApi.Models
{
    public class Mitarbeiter
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }

        [BsonElement("Name")]
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [BsonElement("ApiKey")]
        [JsonPropertyName("ApiKey")]
        public string ApiKey { get; set; }
    }
}
