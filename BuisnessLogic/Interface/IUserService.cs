using DataTransfer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Interface
{
    public interface IUserService
    {
        #region Post
        List<PostDTO> GetAllPosts();
        PostDTO GetPost(int id);
        void CreatePost(string Title, string Body, string Tags);
        void ModifyPost(int post_id, string Title = null, string Body = null, string Tags = null);
        bool DeletePost(int id);
        void LikePost(int id);
        #endregion

        #region Friends
        void AddFriend(int id);
        void DropFriend(int id);

        #endregion
        #region Comment
        void AddComment(int post_id, string text);
        void DeleteComment(int post_id, int comment_id);
        #endregion

        #region User
        bool LoginAsUser(string login, string pass);
        void Unlogin();
        bool CreateNewUser(string Login, string Pwd, string Name,string _Email, List<string> Interests);
        List<UserDTO> GetAllUsers();
        UserDTO GetMe();
        List<string> GetMyFriendsList();
        #endregion

    }
}
