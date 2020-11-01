using DataTransfer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class PostModel
    {
        public int PostId { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }

        public string Body { get; set; }

        public List<string> Tags { get; set; }

        public List<LikeDTO> Likes { get; set; }

        public List<CommentDTO> Comments { get; set; }

    }
}