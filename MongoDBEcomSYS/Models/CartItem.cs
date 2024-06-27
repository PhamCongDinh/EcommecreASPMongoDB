using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBEcomSYS.Models
{
    public class CartItem
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } 
        public string SessionId { get; set; }

        public string ProductId { get; set; }

        public int Quantity { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? Modified { get; set; }
    }
}
