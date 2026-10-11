using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoCrudApi.Models;

public class Game
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("title")]
    public string Title { get; set; } = string.Empty;

    [BsonElement("genre")]
    public string Genre { get; set; } = string.Empty;

    [BsonElement("platform")]
    public string Platform { get; set; } = string.Empty;

    [BsonElement("price")]
    public decimal Price { get; set; }

    [BsonElement("release_year")]
    public int ReleaseYear { get; set; }

    [BsonElement("rating")]
    public double Rating { get; set; }
}