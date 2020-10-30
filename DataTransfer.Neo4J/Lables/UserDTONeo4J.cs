using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer.Neo4J.Lables
{
    public class UserDTONeo4J
    {
        [JsonProperty(PropertyName = "UserId")]
        public int UserId { get; set; }
        [JsonProperty(PropertyName = "UserLogin")]
        public string User_Login { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string UserName { get; set; }


    }
}
