using System;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiTweetsReader.Models
{
    public class Tweet
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public string Texto { get; set; }

        public string DataCriacao { get; set; }

        public string[] Hashtags { get; set; }

        public Usuario Usuario { get; set; }

    }
}