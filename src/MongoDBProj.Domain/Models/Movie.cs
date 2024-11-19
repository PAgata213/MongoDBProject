using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBProj.Domain.Models;
public record Movie
{
	[BsonId]
	[BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
	public Guid Id { get; init; }

	[BsonElement("name"), BsonRepresentation(BsonType.String)]
	public string? Name { get; set; }

	[BsonElement("description"), BsonRepresentation(BsonType.String)]
	public string? Description { get; set; }

	[BsonElement("title"), BsonRepresentation(BsonType.String)]
	public string? Title { get; set; }
}
