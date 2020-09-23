using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace SocialNetwork.DataAccess.Models
{
    public class User
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement("isActive")]
        public bool IsActive { get; set; }

        [BsonElement("name")]
        public Name Name { get; set; }


        [BsonElement("password")]
        public string Password { get; set; }



        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }

        [BsonElement("about")]
        public string About { get; set; }

        [BsonElement("registered")]
        public string Registered { get; set; }

        [BsonElement("friends")]
        public IEnumerable<Friend> Friends { get; set; }

    }
    public class Name
    {
        [BsonElement("first")]
        public string First { get; set; }
        [BsonElement("last")]
        public string Last { get; set; }
    }
    public class Friend
    {
        [BsonElement("id")]
        public double Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
    }
}
