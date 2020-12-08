using Cassandra;
using DataAccess.Concrete;
using DataAccess.Neo4J.Concrete;
using DataTransfer.Models;
using DataTransfer.Neo4J.Lables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Concrete
{
   public class UserManager
    {
        private readonly string mongo_connectionString = "mongodb://localhost:27017/";
        private readonly string neo4j_connectionString = "http://localhost:7474/db/data/";
        private static readonly IPAddress IpAddress = IPAddress.Parse("127.0.0.1"); 
        private readonly string neo4j_login = "neo4j";
        private readonly string neo4j_pass = "1234567890";

        readonly IPEndPoint[] _iPEndPoints =
      {
            new IPEndPoint(IpAddress, 9040), new IPEndPoint(IpAddress, 9041), new IPEndPoint(IpAddress, 9042),
            new IPEndPoint(IpAddress, 9043)
        };
        public ISession GetSession()
        {

            var cluster = Cluster.Builder()
                .AddContactPoints(_iPEndPoints)
                .Build();

            var session = cluster.Connect("social_media");

            return session;

        }
        public UserManager()
        {

        }
        
        public List<UserDTO> GetAllUsers()
        {
            UserDAL dal = new UserDAL();
            return dal.GetAllUsers();
        }

        public List<UserDTONeo4J> GetPathBetweenUsers(int u1_id, int u2_id)
        {
            UserNeo4J dal = new UserNeo4J(mongo_connectionString, neo4j_login, neo4j_pass); 
            var path = dal.MinPathBetweenList(u1_id, u2_id);
            return path;
        }

        public int GetPathLenBetweenUsers(int u1_id, int u2_id)
        {
            UserNeo4J dal = new UserNeo4J(mongo_connectionString, neo4j_login, neo4j_pass); 
            var path = dal.MinPathBetweenList(u1_id, u2_id);
            return path.Count;
        }

        public UserDTO GetUserById(int id)
        {
            UserDAL dal = new UserDAL();
            return dal.GetUserById(id);
        }

        public UserDTO GetUserByLogin(string login)
        {
            UserDAL dal = new UserDAL();
            return dal.GetUserByLogin(login);
        }

        public void CreateRelationship(int id_from, int id_to)
        {
            UserDAL dal = new UserDAL();
            var u = dal.GetUserById(id_from);
            if (u.FriendsId.Contains(id_to))
            {
                return;
            }
            else
            {
                u.FriendsId.Add(id_to);
                u = dal.UpdateUser(u);
                UserNeo4J Neo4jDal = new UserNeo4J(this.neo4j_connectionString, this.neo4j_login, this.neo4j_pass);
                Neo4jDal.AddRelationship(id_from, id_to);
            }

        }

        public bool CreateUser(UserDTO u)
        {
            UserDAL dal = new UserDAL();
            UserNeo4J Neo4jDal = new UserNeo4J(this.neo4j_connectionString, this.neo4j_login, this.neo4j_pass);

            try
            {
                dal.CreateUser(u);
                Neo4jDal.AddUser(new UserDTONeo4J { UserId = u.UserId, UserName = u.UserName, UserLogin = u.UserLogin });
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }

}

