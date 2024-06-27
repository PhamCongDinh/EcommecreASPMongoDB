using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDBEcomSYS.Models
{
    public class Dicounts
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int DiscountPercent { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
