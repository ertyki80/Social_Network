using System;
using System.Collections.Generic;
using SocialNetwork.DataAccess.Models;

namespace SocialNetwork.BusinesLogic.Interfaces
{
    public interface IUserService
    {
        User GetUser(Guid id);
        List<User> GetAllUsers();
        void Create(User user);
        void Update(Guid id, User user);
        void Delete(Guid id);
    }
}
