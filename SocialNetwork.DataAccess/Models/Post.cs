using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess.Models
{
    public class Post
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("body")]
        public string Body { get; set; }

        [BsonElement("tags")]
        public Tags Tags { get; set; }

        [BsonElement("comments")]
        public Comments Comments { get; set; }

        [BsonElement("timeOfCreating")]
        public DateTime TimeOfCreating { get; set; }

        [BsonElement("like")]
        public int Like { get; set; }

    }
    public class Tags
    {
        [BsonElement("id")]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
    }
    public class Comments
    {
        [BsonElement("author")]
        public double Author { get; set; }
        [BsonElement("body")]
        public string Body { get; set; }
    }
}
