using AutoMapper;
using DataTransfer.Models;
using WebApp.Models.Concrete;

namespace WebApp.Models.ProfileApp
{
    public class PostProfile:Profile
    {
        public PostProfile()
        {

            CreateMap<PostDTO, PostModel>()
                .ForMember(dest => dest.PostId, scr => scr.MapFrom(m => m.Post_Id))
                .ForMember(dest => dest.Title, scr => scr.MapFrom(m => m.Title))
                .ForMember(dest => dest.Body, scr => scr.MapFrom(m => m.Body))
                .ForMember(dest => dest.Tags, scr => scr.MapFrom(m => m.Tags))
                .ForMember(dest => dest.Likes, scr => scr.MapFrom(m => m.Likes))
                .ForMember(dest => dest.Comments, scr => scr.MapFrom(m => m.Comments))
                .ForMember(dest => dest.AuthorName, scr => scr.MapFrom(name => GetUserFullName(name.AuthorId)));

        }

        public static string GetUserFullName(int id)
        {
            UserManagerModel u = new UserManagerModel(id);
            var name = u.Get().GetMe().UserName;
            return (name);
        }

    }
}