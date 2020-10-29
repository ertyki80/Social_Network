using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer.Models
{
    public class CommentDTO
    {
        [BsonElement("Comment_Id")]
        public int Comment_Id { get; set; }

        [BsonElement("Author_Id")]
        public int Author_Id { get; set; }
        [BsonElement("Comment_Text")]
        public string Comment_Text { get; set; }
        [BsonElement("Likes")]
        public List<LikesDTO> Likes { get; set; }
        [BsonElement("Dislikes")]
        public List<DislikeDTO> Dislikes { get; set; }

        [BsonElement("Create_Date")]
        public BsonTimestamp Create { get; set; }

        [BsonElement("Modify_Date")]
        public BsonTimestamp Modify { get; set; }
    }
}
