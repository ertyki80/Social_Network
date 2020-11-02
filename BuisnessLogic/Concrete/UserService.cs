using BuisnessLogic.Interface;
using DataAccess.Concrete;
using DataTransfer.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Concrete
{
    public class UserService : IUserService
    {
        private int user_id;
        private bool Logined;
        public UserService(int id)
        {
            user_id = id;
            Logined = false;

        }
        public void AddComment(int post_id, string text)
        {
            CommentDTO comment = new CommentDTO()
            {
                Author_Id = this.user_id,
                Comment_Text = text,
                Likes = new List<LikeDTO>(),
                Create = new BsonTimestamp(DateTime.UtcNow.ToBinary()),
                Modify = new BsonTimestamp(DateTime.UtcNow.ToBinary())

            };
            PostDAL dal = new PostDAL();
            dal.AddCommentToPost(post_id, comment);


        }

        public void AddFriend(int id)
        {
            if (this.Logined)
            {
                var acc = GetMe();
                if (!acc.FriendsId.Contains(id))
                {
                    acc.FriendsId.Add(id);
                    UserDAL dal = new UserDAL();
                    dal.UpdateUser(acc);
                }
            }

        }

        public bool CreateNewUser(string Login, string Pwd, string Name, string _Email, List<string> Interests)
        {
            UserDAL dal = new UserDAL();
            UserDTO new_user = new UserDTO
            {
                UserLogin = Login,
                UserPassword = Pwd,
                UserName = Name,
                Interests = Interests,
                RegisterDate = new BsonTimestamp(DateTime.UtcNow.ToBinary()),
                Email = _Email,
                FriendsId = new List<int>()
            };
            try
            {
                var res = dal.GetUserByLogin(Login);
                if (res.Id != null)
                {
                    throw new Exception("User with this login already created");
                }
            }
            catch (Exception exp)
            {
                if (exp.Message == "User with this login already created")
                {
                    return false;
                }
            }
            var Account = dal.CreateUser(new_user);
            if (Account.Id != null)
            {
                this.user_id = Account.UserId;
                this.Logined = true;
                return true;

            }

            return false;

        }

        public void CreatePost(string Title, string Body, string Tags)
        {
            PostDTO post = new PostDTO()
            {
                Author_Id = this.user_id,
                Title = Title,
                Body = Body,
                Tags = Tags.Split(',').ToList(),
                Create = new BsonTimestamp(DateTime.UtcNow.ToBinary()),
                Modify = new BsonTimestamp(DateTime.UtcNow.ToBinary()),
                Comments = new List<CommentDTO>(),
                Likes = new List<LikeDTO>(),
            };
            PostDAL dal = new PostDAL();
            try
            {
                dal.CreatePost(post);
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }

        public void DeleteComment(int post_id, int comment_id)
        {
            PostDAL dal = new PostDAL();
            dal.DeleteComment(post_id, comment_id);

        }

        public bool DeletePost(int id)
        {
            PostDAL dal = new PostDAL();
            PostDTO post;
            try
            {
                post = dal.GetPostById(id);
            }
            catch (Exception exp)
            {
                throw exp;
            }
            if (post.Author_Id == this.user_id)
            {
                try
                {
                    dal.DeletePost(id);
                }
                catch (Exception exp)
                {
                    throw exp;
                }

                return true;
            }
            return false;


        }

        public void DropFriend(int id)
        {
            if (this.Logined)
            {
                var acc = GetMe();
                if (acc.FriendsId.Contains(id))
                {
                    acc.FriendsId.Remove(id);
                    UserDAL dal = new UserDAL();
                    dal.UpdateUser(acc);
                }
            }

        }

        public List<PostDTO> GetAllPosts()
        {
            PostDAL dal = new PostDAL();
            return dal.GetAllPosts();
        }

        public List<UserDTO> GetAllUsers()
        {
            UserDAL dal = new UserDAL();
            return dal.GetAllUsers();
        }

        public UserDTO GetMe()
        {
            UserDAL dal = new UserDAL();
            return dal.GetUserById(this.user_id);
        }

        public List<string> GetMyFriendsList()
        {
            UserDAL dal = new UserDAL();
            var list = this.GetMe().FriendsId;
            var res = new List<string>();
            foreach (var p in list)
            {
                var temp = dal.GetUserById(p);
                res.Add(temp.UserName);
            }
            return res;

        }

        public PostDTO GetPost(int id)
        {
            PostDAL dal = new PostDAL();
            return dal.GetPostById(id);
        }

        public void LikePost(int id)
        {
            PostDAL dal = new PostDAL();
            bool has_like = false;
            PostDTO post;
            try
            {
                post = dal.GetPostById(id);

            }
            catch (Exception)
            {
                return;
            }
            foreach (var l in post.Likes)
            {
                if (l.User_Id == this.user_id)
                {
                    has_like = true;
                    break;
                }
            }
            if (!has_like)
            {
                LikeDTO like = new LikeDTO() { User_Id = this.user_id };
                dal.Like(id, like);
            }
            else
            {
                LikeDTO like = new LikeDTO() { User_Id = this.user_id };
                dal.UnLike(id, like);
            }

        }

        public bool LoginAsUser(string login, string pass)
        {
            UserDAL user = new UserDAL();
            UserDTO temp;
            try
            {
                temp = user.GetUserByLogin(login);
            }
            catch (Exception exp)
            {
                return false;
            }
            if (temp.Id != null)
            {
                if (temp.UserPassword == pass)
                {
                    this.user_id = temp.UserId;
                    Logined = true;
                    return true;
                }
            }

            return false;
        }

        public void ModifyPost(int post_id, string Title = null, string Body = null, string Tags = null)
        {
            PostDTO post = new PostDTO()
            {
                Title = Title,
                Body = Body,
                Tags = (Tags == null) ? null : Tags.Split().ToList(),
                Modify = new BsonTimestamp(DateTime.UtcNow.ToBinary()),
            };
            PostDAL dal = new PostDAL();
            dal.UpdatePost(post);

        }

        public void Unlogin()
        {
            this.user_id = 0;
            this.Logined = false;
        }
    }
}
