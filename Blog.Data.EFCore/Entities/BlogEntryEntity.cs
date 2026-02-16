using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Blog.Data.EFCore.Entities;

public class BlogEntryEntity
{
    [BsonId]
	public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
	public string Title { get; set; } = string.Empty;
    public string Entry { get; set; } = string.Empty;
	public DateTime PostedDate { get; set; }	
	public ICollection<string> Tags { get; set; } = [];
}
