using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDBEcomSYS.Models
{
    public class UserAddress
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string UserID { get; set; }
        public string? AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        public string? City { get; set; }

        public string? PostalCode { get; set; }

        public string? Country { get; set; }

        public string? Telephone { get; set; }

        public string? Mobile { get; set; }
    }
}
