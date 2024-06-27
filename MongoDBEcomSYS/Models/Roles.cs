using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDBEcomSYS.Models
{
    public class Roles
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; }
    }
}
