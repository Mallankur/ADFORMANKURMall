using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AdformAPI.Entites
{
    public class AdformProduct
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String? Id { get; set; }

        [BsonElement("Name")]
        public string? Name { get; set; }
        public string? Summary { get; set; }    
        public string? Category { get; set; }
        public string? Description { get; set; }
        public string? ImageFile { get; set; }
        public double? Price { get; set; }
    }
}
