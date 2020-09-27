using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.DataAccess.Models;

namespace SocialNetwork.BusinesLogic.Interfaces
{
    interface IPostService
    {
        Post GetPosts(Guid id);
        List<Post> GetAllPosts();
        void Create(Post user);
        void Update(Guid id, Post user);
        void Delete(Guid id);

    }
}
