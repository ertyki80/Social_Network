using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.BusinesLogic.Service;
using SocialNetwork.DataAccess.Context;
using SocialNetwork.DataAccess.Models;

namespace SocialNetwork.BusinesLogic.Helpers
{
    public class AutorizeLogic
    {
        public bool UserRecognition = false;

        private User _currentUser;

        public AutorizeLogic()
        {
            _currentUser= new User();
        }
        public bool Login(string email, string password)
        {


            var context = new DataContext();
            var user = context.Users.Find(c => c.Email == email && c.Password == password);
            UserRecognition = user != null;
            _currentUser = user;
            return UserRecognition;

        }

        public User GetUser()
        {
            return _currentUser;

        }

        public User Registration(string name, string password, string email, string phone, string about)
        {
            var context = new Context();
            var userService = new UserService();
            var newUser = new User()
            {
                Id=Guid.NewGuid().ToString(),
                Name=name,
                Password = password,
                About = about,
                Email = email,
                Phone = phone,
                Registered = DateTime.Now.ToString()
            };
            _currentUser = newUser;
            userService.Create(newUser);
            return _currentUser;
        }
    }
}
