using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ConsoleTweetsReader.Models
{
    public class Tweet
    {
        public Tweet()
        {
            this.Hashtags = new List<string>();
            this.Usuario = new Usuario();
        }

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public string Texto { get; set; }

        public string DataCriacao { get; set; }

        public List<string> Hashtags { get; set; }

        public Usuario Usuario { get; set; }
    }
}