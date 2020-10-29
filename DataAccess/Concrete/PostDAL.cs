using AutoMapper;
using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.MongoDB;
using DataTransfer.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class PostDAL : IPostDAL
    {
        public void AddCommentToPost(int id, CommentDTO comment)
        {
            try
            {
                var data = new DataContext();
                var db = data.database._db;
                var posts = db.GetCollection<PostDTO>("Posts");
                var UpdateFilter = Builders<PostDTO>.Update.AddToSet("Comments", comment);
                posts.UpdateOne(g => g.Post_Id == id, UpdateFilter);

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public PostDTO CreatePost(PostDTO post)
        {
            try
            {
                var data = new DataContext();
                var db = data.database._db;
                var posts = db.GetCollection<PostDTO>("Posts");
                var count_id = posts.CountDocuments(p => p.Post_Id > 0);
                post.Post_Id = (int)count_id + 1;
                posts.InsertOne(post);
                return post;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void DeleteComment(int post_id, int comment_id)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(int id)
        {
            try
            {
                var data = new DataContext();
                var db = data.database._db;
                var posts = db.GetCollection<PostDTO>("Posts");
                posts.DeleteOne(p => p.Post_Id == id);
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }

        public List<PostDTO> GetAllPosts()
        {
            try
            {
                var data = new DataContext();
                var db = data.database._db;
                var posts = db.GetCollection<PostDTO>("Posts");
                var all_posts = posts.Find(p => p.Post_Id > 0).ToList();
                return all_posts;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public PostDTO GetPostById(int id)
        {

            try
            {
                var data = new DataContext();
                var db = data.database._db;
                var posts = db.GetCollection<PostDTO>("Posts");
                var post = posts.Find(p => p.Post_Id == id).Single();
                return post;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public void Like(int post_id, LikeDTO like)
        {
            try
            {

                var data = new DataContext();
                var db = data.database._db;
                var posts = db.GetCollection<PostDTO>("Posts");
                var UpdateFilter = Builders<PostDTO>.Update.AddToSet("Likes", like);
                posts.UpdateOne(g => g.Post_Id == post_id, UpdateFilter);
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }

        public void UnLike(int post_id, LikeDTO like)
        {
            try
            {
                var data = new DataContext();
                var db = data.database._db;
                var posts = db.GetCollection<PostDTO>("Posts");
                var UpdateFilter = Builders<PostDTO>.Update.Pull("Likes", like);
                posts.UpdateOne(g => g.Post_Id == post_id, UpdateFilter);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public PostDTO UpdatePost(PostDTO post)
        {
            try
            {
                var data = new DataContext();
                var db = data.database._db;
                var posts = db.GetCollection<PostDTO>("Posts");
                var UpdateFilter = Builders<PostDTO>.Update.Set("Post_Id", post.Post_Id);
                if (post.Author_Id != 0) { UpdateFilter = UpdateFilter.Set("Author_Id", post.Author_Id); }
                if (post.Title != null) { UpdateFilter = UpdateFilter.Set("Title", post.Title); }
                if (post.Body != null) { UpdateFilter = UpdateFilter.Set("Body", post.Body); }
                if (post.Tags != null) { UpdateFilter = UpdateFilter.Set("Tags", post.Tags); }
                UpdateFilter = UpdateFilter.Set("Modify", DateTime.Now);
                posts.UpdateOne(g => g.Post_Id == post.Post_Id, UpdateFilter);
                var res = posts.Find(p => p.Post_Id == post.Post_Id).Single();
                return res;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
