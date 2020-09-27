using System;
using System.Collections.Generic;
using SocialNetwork.BusinesLogic.Interfaces;
using SocialNetwork.DataAccess.Helpers;
using SocialNetwork.DataAccess.Models;

namespace SocialNetwork.BusinesLogic.Service
{
    class UserService:IUserService
    {
        

        const string connectionString = "mongodb://localhost:27017";
        const string databaseName = "social_network";
        const string collectionName = "users";

        static DBHelper dbHelper;
        public  UserService()
        {
            dbHelper = DBHelper.CreateInstance(connectionString, databaseName);
        }
        public User GetUser(Guid id)
        {
            return dbHelper.LoadDocumentById<User>(collectionName, id);
        }

        public List<User> GetAllUsers()
        {
            return dbHelper.LoadAllDocuments<User>(collectionName);
        }

        public void Create(User user)
        {
            dbHelper.InsertDocument(collectionName, user);
        }

        public void Update(Guid id, User user)
        {
            dbHelper.UpdateDocument(collectionName, id, user);
        }

        public void Delete(Guid id)
        {
            dbHelper.DeleteDocument<User>(collectionName, id);
        }
    }
}
