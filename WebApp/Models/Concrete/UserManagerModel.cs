using BuisnessLogic.Concrete;
using System;
using WebApp.Models.Interfaces;

namespace WebApp.Models.Concrete
{
    public class UserManagerModel : IUserManagerModel
    {
        public int UserId { get; set; }

        public UserManagerModel()
        {
            
        }
        public UserManagerModel(int id)
        {
            this.UserId = id;
        }
        public bool Login(string name, string pass)
        {
            var u = this.Get();
            if (u.LoginAsUser(name, pass))
            {
                this.UserId = Convert.ToInt32(u.GetMe().Id);
                return true;
            }
            return false;
        }
        public bool Register(RegisterModel user)
        {
            var u = this.Get();
            if (u.CreateNewUser(user.UserLogin, user.UserPassword, user.UserName, user.Email, user.Interests))
            {
                this.UserId = Convert.ToInt32(u.GetMe().Id);
                return true;
            }
            return false;
        }

        public UserService Get()
        {
            return new UserService(this.UserId);
        }

        public void Set(int id)
        {
            this.UserId = id;
        }
    }
}