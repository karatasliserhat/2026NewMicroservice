using MongoDB.Bson.Serialization.Attributes;

namespace _2026NewMicroservice.Catalog.API.Repositories
{
    public class BaseEntity
    {
        [BsonElement("_id")] public Guid Id { get; set; }
    }
}
