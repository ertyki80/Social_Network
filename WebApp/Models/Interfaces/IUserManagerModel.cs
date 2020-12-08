using BuisnessLogic.Concrete;

namespace WebApp.Models.Interfaces
{
    interface IUserManagerModel
    {
        int UserId { get; set; }
        UserService Get();
        void Set(int id);
    }
}
