using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDBEcomSYS.Models
{
    public class OrderItem
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? OrderId { get; set; }

        public string ProductId { get; set; }

        public int? Quantity { get; set; }

    }
}
