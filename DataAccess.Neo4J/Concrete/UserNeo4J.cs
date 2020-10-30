using DataTransfer.Neo4J.Lables;
using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Neo4J.Interfaces;


namespace DataAccess.Neo4J.Concrete
{
    public class UserNeo4J: IUserNeo4J
    {
        private string connectionString;
        private string login;
        private string pass;
        public UserNeo4J(string connectionString, string login, string pass)
        {
            this.connectionString = connectionString;
            this.login = login;
            this.pass = pass;
        }
        public void AddRelationship(UserDTONeo4J u1, UserDTONeo4J u2)
        {
            using (GraphClient client = new GraphClient(new Uri(connectionString), login, pass))
            {
                client.Connect();
                client.Cypher
                    .Match("(user1:User),(user2:User)")
                    .Where("user1.User_Id = {p_id1}")
                    .AndWhere("user2.User_Id = {p_id2}")
                    .WithParam("p_id1", u1.UserId)
                    .WithParam("p_id2", u2.UserId)
                    .Create("(user1)-[:Friends]->(user2)")
                    .ExecuteWithoutResults();
            }
        }
        public void AddRelationship(int u1_id, int u2_id)
        {
            using (var client = new GraphClient(new Uri(connectionString), login, pass))
            {
                client.Connect();
                client.Cypher
                    .Match("(user1:User),(user2:User)")
                    .Where("user1.User_Id = {p_id1}")
                    .AndWhere("user2.User_Id = {p_id2}")
                    .WithParam("p_id1", u1_id)
                    .WithParam("p_id2", u2_id)
                    .Create("(user1)-[:Friends]->(user2)")
                    .ExecuteWithoutResults();
            }
        }

        public void AddUser(UserDTONeo4J u)
        {
            using (var client = new GraphClient(new Uri(connectionString), login, pass))
            {
                client.Connect();

                client.Cypher.Create("(u:User { User_Id: {p1},UserLogin: {p2},FisrtName: {p3},LastName: {p4} })")
                    .WithParam("p1", u.UserId)
                    .WithParam("p2", u.UserLogin)
                    .WithParam("p3", u.UserName)
                    .ExecuteWithoutResults();
            }
        }

        public void DeleteRelationship(UserDTONeo4J u1, UserDTONeo4J u2)
        {
            using (var client = new GraphClient(new Uri(connectionString), login, pass))
            {
                client.Connect();
                client.Cypher
                    .Match("(user1:User)-[r:Friends]-(user2:User)")
                    .Where("user1.User_Id = {p_id1}")
                    .AndWhere("user2.User_Id = {p_id2}")
                    .WithParam("p_id1", u1.UserId)
                    .WithParam("p_id2", u2.UserId)
                    .Delete("r")
                    .ExecuteWithoutResults();

            }
        }
        public void DeleteRelationship(int u1_id, int u2_id)
        {
            using (var client = new GraphClient(new Uri(connectionString), login, pass))
            {
                client.Connect();
                client.Cypher
                    .Match("(user1:User)-[r:Friends]-(user2:User)")
                    .Where("user1.User_Id = {p_id1}")
                    .AndWhere("user2.User_Id = {p_id2}")
                    .WithParam("p_id1", u1_id)
                    .WithParam("p_id2", u2_id)
                    .Delete("r")
                    .ExecuteWithoutResults();
            }
        }

        public void DeleteUser(UserDTONeo4J u)
        {
            using (var client = new GraphClient(new Uri(connectionString), login, pass))
            {
                client.Connect();
                client.Cypher
                    .Match("(user1:User)-[r:Friends]-()")
                    .Where("user1.User_Id = {p_id}")
                    .WithParam("p_id", u.UserId)
                    .Delete("r,user1")
                    .ExecuteWithoutResults();

            }
        }

        public UserDTONeo4J GetUser(int id)
        {
            using (var client = new GraphClient(new Uri(connectionString), login, pass))
            {
                client.Connect();
                var user = client.Cypher
                    .Match("(u:User)")
                    .Where((UserDTONeo4J u) => u.UserId == id)
                    .Return(u => u.As<UserDTONeo4J>())
                    .Results;
                UserDTONeo4J to_ret = new UserDTONeo4J() { UserId = id };
                foreach (var u in user)
                {
                    to_ret.UserId = u.UserId;
                    to_ret.UserLogin = u.UserLogin;
                    to_ret.UserName = u.UserName;
                }
                return to_ret;


            }
        }

        public bool HasRelationship(UserDTONeo4J u1, UserDTONeo4J u2)
        {
            using (var client = new GraphClient(new Uri(connectionString), login, pass))
            {
                client.Connect();
                var is_friends = client.Cypher
                   .Match("(user1:User)-[r:Friends]-(user2:User)")
                   .Where((UserDTONeo4J user1) => user1.UserId == u1.UserId)
                   .AndWhere((UserDTONeo4J user2) => user2.UserId == u2.UserId)
                   .Return(r => r.As<FriendsDTONeo4J>()).Results;
                if (is_friends.Count() > 0)
                {
                    return true;
                }
                return false;

            }
        }

        public int MinPathBetween(UserDTONeo4J u1, UserDTONeo4J u2)
        {
            return this.MinPathBetween(u1.UserId, u2.UserId);
        }

        public int MinPathBetween(int id1, int id2)
        {
            using (var client = new GraphClient(new Uri(connectionString), login, pass))
            {
                client.Connect();
                var res = client.Cypher
                    .Match("(u1:User{User_Id: {p_id1} }),(u2:User{User_Id: {p_id2} })," +
                    " p = shortestPath((u1)-[:Friends*]-(u2))")
                    .WithParam("p_id1", id1)
                    .WithParam("p_id2", id2)
                    .Return(ret => ret.As<FriendsDTONeo4J>())
                    .Results;
                int path_len = -1;
                foreach (var t in res)
                {
                    path_len = Convert.ToInt32(t.Length);
                }
                return path_len;
            }
        }

        public List<UserDTONeo4J> MinPathBetweenList(int id1, int id2)
        {
            using (var client = new GraphClient(new Uri(connectionString), login, pass))
            {
                if (id1 == id2) { return new List<UserDTONeo4J>(); ; }
                client.Connect();
                var res = client.Cypher
                    .Match("(u1:User{User_Id: {p_id1} }),(u2:User{User_Id: {p_id2} })," +
                    " p = shortestPath((u1)-[:Friends*]-(u2))")
                    .WithParam("p_id1", id1)
                    .WithParam("p_id2", id2)
                    .Return((ret, len) => new
                    {
                        shortestPath = Neo4jClient.Cypher.Return.As<IEnumerable<Node<UserDTONeo4J>>>("nodes(p)")
                    })
                    .Results;
                List<UserDTONeo4J> to_ret = new List<UserDTONeo4J>();
                foreach (var item in res)
                {
                    foreach (var it in item.shortestPath.ToList())
                    {
                        to_ret.Add(it.Data);
                    }
                }
                return to_ret;
            }
        }

    }
}
