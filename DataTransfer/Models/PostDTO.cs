﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer.Models
{
    public class PostDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; }
        [BsonElement("Post_Id")]
        public int Post_Id { get; set; }

        [BsonElement("Author_Id")]
        public int Author_Id { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("Body")]
        public string Body { get; set; }

        [BsonElement("Tags")]
        public List<string> Tags { get; set; }

        [BsonElement("Likes")]
        public List<LikesDTO> Likes { get; set; }

        [BsonElement("Comments")]
        public List<CommentDTO> Comments { get; set; }

        [BsonElement("Create_Date")]
        public BsonTimestamp Create { get; set; }

        [BsonElement("Modify_Date")]
        public BsonTimestamp Modify { get; set; }

    }
}
