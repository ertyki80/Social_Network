using AutoMapper;
using DataTransfer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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