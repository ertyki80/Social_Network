using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer.Models
{
    public class LikeDTO
    {
        [BsonElement("User_Id")]
        public int User_Id { get; set; }


    }
}
