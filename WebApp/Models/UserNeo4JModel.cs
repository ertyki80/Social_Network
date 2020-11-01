using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class UserNeo4JModel
    {
        public int UserFromId { get; set; }
        public int UserToId { get; set; }
        public List<UserModel> PathToUser { get; set; }
        public int PathLen { get; set; }

    }
}