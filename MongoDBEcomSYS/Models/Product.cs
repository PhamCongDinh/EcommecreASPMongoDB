using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDBEcomSYS.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;
    using System.Collections.Generic;

    public class Product
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }

        public string Desc { get; set; }

        public string Image { get; set; }

        public string Sku { get; set; }

        public decimal Price { get; set; }
        public ProductInventory Inventory { get; set; }
        public ProductCategory Category { get; set; }
        public Dicounts? Dicount { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        
    }

    
}