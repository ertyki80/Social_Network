
using DataAccess.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    class DataContext
    {
        public DBHelper database;
        public DataContext()
        {
            string connectionString = "mongodb://localhost:27017";
            string databaseName = "social_network";
            database = new DBHelper(connectionString, databaseName);
        }
    }
}
