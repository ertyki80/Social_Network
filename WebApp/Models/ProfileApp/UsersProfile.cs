using AutoMapper;
using DataTransfer.Models;

namespace WebApp.Models.ProfileApp
{
    public class UsersProfile:Profile
    {
        UsersProfile()
        {
            CreateMap<FullUserModel, UserDTO>().ReverseMap();
        }
    }
}