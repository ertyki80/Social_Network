using DataTransfer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public  interface IUserDAL
    {
        UserDTO GetUserById(int id);
        List<UserDTO> GetAllUsers();
        UserDTO UpdateUser(UserDTO user);
        UserDTO CreateUser(UserDTO user);
        void DeleteUser(int id);

    }
}
