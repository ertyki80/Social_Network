using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace SocialNetwork.DataAccess.Models
{
    public class Post
    {
        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("body")]
        public string Body { get; set; }

        [BsonElement("tags")]
        public IEnumerable<Tags> Tags { get; set; }

        [BsonElement("comments")]
        public IEnumerable<Comments> Comments { get; set; }

        [BsonElement("timeOfCreating")]
        public string TimeOfCreating { get; set; }

        [BsonElement("like")]
        public int Like { get; set; }

    }

    public class Tags
    {
        [BsonElement("id")]
        public string Id_ { get; set; }

        [BsonElement("name")]
        public string Name_ { get; set; }
    }
    public class Comments
    {
        [BsonElement("author")] 
        public string Author { get; set; }
        [BsonElement("body")]
        public string Body { get; set; }
    }
}
