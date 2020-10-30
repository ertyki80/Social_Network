using DataTransfer.Neo4J.Lables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Neo4J.Interfaces
{
    public interface IUserNeo4J
    {
        void AddUser(UserDTONeo4J user);
        void DeleteUser(UserDTONeo4J user); 
        UserDTONeo4J GetUser(int id);
        void DeleteRelationship(UserDTONeo4J user1, UserDTONeo4J user2);
        void AddRelationship(UserDTONeo4J user1, UserDTONeo4J user2);
        bool HasRelationship(UserDTONeo4J user1, UserDTONeo4J user2);
        int MinPathBetween(UserDTONeo4J user1, UserDTONeo4J user2);
        int MinPathBetween(int id1, int id2);
        List<UserDTONeo4J> MinPathBetweenList(int id1, int id2);

    }
}
