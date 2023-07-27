using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookStore.Domain.Models
{
    [BsonIgnoreExtraElements]
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int PublicationYear { get; set; }
    }
}
