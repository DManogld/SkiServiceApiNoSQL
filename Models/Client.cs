
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SkiServiceApi.Models;

/// <summary>
/// Client Model Klasse
/// </summary>
public class Client
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? _id { get; set; }

    [BsonElement("Name")]
    [JsonPropertyName("Name")]
    public string Name { get; set; } = null!;

    [BsonElement("EMail")]
    [JsonPropertyName("Email")]
    public string EMail { get; set; } = null!;

    [BsonElement("Phone")]
    [JsonPropertyName("Phone")]
    public string Phone { get; set; }

    [BsonElement("CreateDate")]
    [JsonPropertyName("CreateDate")]
    public string CreateDate { get; set; }

    [BsonElement("PickupDate")]
    [JsonPropertyName("PickupDate")]
    public string PickupDate { get; set; }

    [BsonElement("Kommentar")]
    [JsonPropertyName("Kommentar")]
    public string Kommentar { get; set; }

    [BsonElement("Status")]
    [JsonPropertyName("Status")]
    public string Status { get; set; } = null!;

    [BsonElement("Priority")]
    [JsonPropertyName("Priority")]
    public string Priority { get; set; } = null!;

    [BsonElement("Facility")]
    [JsonPropertyName("Facility")]
    public string Facility { get; set; } = null!;
}
