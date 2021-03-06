﻿using System.Collections.Generic;
using AutoMapper;
using DataTransfer.Models;
using DataTransfer.Neo4J.Lables;
using WebApp.Models.Concrete;

namespace WebApp.Models.ProfileApp
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, UserModel>()
                .ForMember(dest => dest.UserId, scr => scr.MapFrom(u => u.UserId))
                .ForMember(dest => dest.UserName, scr => scr.MapFrom(u => u.UserName))
                .ForMember(dest => dest.Interests, scr => scr.MapFrom(u => u.Interests)).ReverseMap();
            CreateMap<UserDTONeo4J, UserModel>()
                .ForMember(dest => dest.UserId, scr => scr.MapFrom(u => u.UserId))
                .ForMember(dest => dest.UserName, scr => scr.MapFrom(u => u.UserName))
                .ForMember(dest => dest.Interests, scr => scr.MapFrom(u => GetUserInterests(u.UserId))).ReverseMap();

        }
        public static List<string> GetUserInterests(int id)
        {
            var manager = new UsersManagerModel();
            var user = manager.GetUserById(id);
            return user.Interests;
        }
    }

}