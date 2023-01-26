
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SkiServiceApi.Models;

public class Client
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? _id { get; set; }

    [BsonElement("Name")]
    [JsonPropertyName("Name")]
    public string Name { get; set; } = null!;

    public string EMail { get; set; } = null!;

    public string Phone { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime PickupDate { get; set; }

    public string Kommentar { get; set; }

    public string Status { get; set; } = null!;

    public string Priority { get; set; } = null!;

    public string Facility { get; set; } = null!;
}
