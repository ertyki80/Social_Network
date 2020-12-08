using System.Collections.Generic;

namespace WebApp.Models
{
    public class RegisterModel
    {
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Interests { get; set; }
    }
}