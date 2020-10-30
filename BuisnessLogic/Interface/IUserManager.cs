using DataTransfer.Models;
using DataTransfer.Neo4J.Lables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Interface
{
    public interface IUserManager
    {
        int GetPathLen(int u1_id, int u2_id);
        List<UserDTONeo4J> GetPath(int u1_id, int u2_id);
        List<UserDTO> GetAll();
        UserDTO GetUserById(int id);
        UserDTO GetUserByLogin(string login);
        bool CreateUser(UserDTO u);
        void CreateRelationship(int id_from, int id_to);

    }
}
