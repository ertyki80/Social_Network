using BuisnessLogic.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models.Interfaces
{
    interface IUserManagerModel
    {
        int UserId { get; set; }
        UserService Get();
        void Set(int id);
    }
}
