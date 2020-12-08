using System.Collections.Generic;

namespace WebApp.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public List<string> Interests { get; set; }

    }
}