using DataAccess.Context;
using DataAccess.Interfaces;
using DataTransfer.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class UserDAL : IUserDAL
    {
        
        public UserDTO CreateUser(UserDTO user)
        {
            
            try
            {
                var db = (new DataContext()).database._db;
                IMongoCollection<UserDTO> users = db.GetCollection<UserDTO>("Users");
                var count_id = users.CountDocuments(p => p.UserId >= 0);
                user.UserId = (int)count_id + 1;
                users.InsertOne(user);
                return user;
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }

        public void DeleteUser(int id)
        {
            try
            {


                var db = (new DataContext()).database._db;
                var users = db.GetCollection<UserDTO>("Users");
                users.DeleteOne(p => p.UserId == id);
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }

        public List<UserDTO> GetAllUsers()
        {
            try
            {
                var db = (new DataContext()).database._db;
                var users = db.GetCollection<UserDTO>("Users");

                var all_users = users.Find(p => p.UserId >= 0).ToList();
                return all_users;
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }
        public UserDTO GetUserByLogin(string login)
        {
            try
            {

                var db = (new DataContext()).database._db;
                var users = db.GetCollection<UserDTO>("Users");
                var founded = users.Find(p => p.UserLogin == login).Single();
                return founded;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public UserDTO GetUserById(int id)
        {
            try
            {
                var db = (new DataContext()).database._db;
                var users = db.GetCollection<UserDTO>("Users");
                var founded = users.Find(p => p.UserId == id).Single();
                return founded;
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }

        public UserDTO UpdateUser(UserDTO user)
        {
            try
            {
                var db = (new DataContext()).database._db;
                var users = db.GetCollection<UserDTO>("Users");
                var UpdateFilter = Builders<UserDTO>.Update.Set("User_Id", user.UserId);
                if (user.UserLogin != null) { UpdateFilter = UpdateFilter.Set("UserLogin", user.UserLogin); }
                if (user.UserPassword != null) { UpdateFilter = UpdateFilter.Set("UserPassword", user.UserPassword); }
                if (user.UserName != null) { UpdateFilter = UpdateFilter.Set("UserName", user.UserName); }
                if (user.FriendsId != null) { UpdateFilter = UpdateFilter.Set("FriendsId", user.FriendsId); }
                if (user.Interests != null) { UpdateFilter = UpdateFilter.Set("Interests", user.Interests); }
                if (user.Email != null) { UpdateFilter = UpdateFilter.Set("Email", user.Email); }
                users.UpdateOne(g => g.UserId == user.UserId, UpdateFilter);
                var res = users.Find(p => p.UserId == user.UserId).Single();
                return res;
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }
    }
}
