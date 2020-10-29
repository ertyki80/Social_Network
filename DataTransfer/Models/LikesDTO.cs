using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer.Models
{
    public class LikesDTO
    {
        [BsonElement("User_Id")]
        public int User_Id { get; set; }

        [BsonElement("User_Id")]
        public int Count { get; set; }

    }
}
