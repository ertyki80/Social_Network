using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer.Models
{
    public class CommentDTO
    {
        [BsonElement("CommentId")]
        public int Comment_Id { get; set; }

        [BsonElement("AuthorId")]
        public int Author_Id { get; set; }
        [BsonElement("CommentText")]
        public string Comment_Text { get; set; }
        [BsonElement("Likes")]
        public List<LikeDTO> Likes { get; set; }

        [BsonElement("CreateDate")]
        public BsonTimestamp Create { get; set; }

        [BsonElement("ModifyDate")]
        public BsonTimestamp Modify { get; set; }
    }
}
