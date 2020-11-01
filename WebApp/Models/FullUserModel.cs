using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class FullUserModel
    {
        public int UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Interests { get; set; }
        public List<int> Friends_Ids { get; set; }
    }
}