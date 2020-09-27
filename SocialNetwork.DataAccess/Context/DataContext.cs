using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using SocialNetwork.DataAccess.Helpers;
using SocialNetwork.DataAccess.Models;

namespace SocialNetwork.DataAccess.Context
{
    public class DataContext
    {
        public List<User> Users;
        public List<Post> Posts;
        public DataContext()
        {

            var connectionString = "mongodb://localhost:27017";
            const string databaseName = "social_network";
            DBHelper database = DBHelper.CreateInstance(connectionString, databaseName);
            Users = database.LoadAllDocuments<User>("users");
            Posts = database.LoadAllDocuments<Post>("posts");



        }
    }
}