using AutoMapper;
using DataTransfer.Models;

namespace WebApp.Models.ProfileApp
{
    public class RegisterProfile:Profile
    {
        public RegisterProfile()
        {
            CreateMap<RegisterModel, UserDTO>().ReverseMap();
        }

    }
}