using SocialNetwork.BusinesLogic.Interfaces;
using SocialNetwork.DataAccess.Models;
using System;
using System.Collections.Generic;
using SocialNetwork.DataAccess.Helpers;

namespace SocialNetwork.BusinesLogic.Service
{
    class PostService : IPostService
    {

        const string connectionString = "mongodb://localhost:27017";
        const string databaseName = "social_network";
        const string collectionName = "posts";

        static DBHelper dbHelper;

        PostService()
        {
            dbHelper = DBHelper.CreateInstance(connectionString, databaseName);
        }

        public void Create(Post user)
        {
            dbHelper.InsertDocument(collectionName, user);

        }

        public void Delete(Guid id)
        {
            dbHelper.DeleteDocument<Post>(collectionName,id);
        }

        public List<Post> GetAllPosts()
        {
            return dbHelper.LoadAllDocuments<Post>(collectionName);
        }

        public Post GetPosts(Guid id)
        {
            return dbHelper.LoadDocumentById<Post>(collectionName, id);
        }

        public void Update(Guid id, Post user)
        {
            dbHelper.UpdateDocument(collectionName, id, user);
        }
    }
}
