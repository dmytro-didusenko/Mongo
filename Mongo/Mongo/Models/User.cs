using MongoDB.Bson.Serialization.Attributes;

namespace Mongo.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("name")]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Name { get; set; } = string.Empty;

        [BsonElement("email")]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Email { get; set; } = string.Empty;

        [BsonElement("age")]
        [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        public int Age { get; set; }

        [BsonElement("hasCar")]
        [BsonRepresentation(MongoDB.Bson.BsonType.Boolean)]
        public bool HasCar { get; set; }

        [BsonElement("birthday")]
        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        [BsonIgnoreIfNull]
        public DateTime BirthDay { get; set; }

        [BsonElement("favColor")]
        [BsonIgnoreIfNull]
        public IEnumerable<string> Colors { get; set; } = null!;
    }
}
