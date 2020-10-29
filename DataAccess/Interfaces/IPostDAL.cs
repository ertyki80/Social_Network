using DataTransfer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IPostDAL
    {
        PostDTO GetPostById(int id);
        List<PostDTO> GetAllPosts();
        PostDTO UpdatePost(PostDTO post);
        PostDTO CreatePost(PostDTO post);
        void DeletePost(int id);
        void Like(int post_id, LikeDTO like);
        void UnLike(int post_id, LikeDTO like);

        void AddCommentToPost(int id, CommentDTO comment);
        void DeleteComment(int post_id, int comment_id);
    }
}
