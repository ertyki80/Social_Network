using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer.Neo4J.Lables
{
    public class FriendsDTONeo4J
    {
            [JsonProperty(PropertyName = "length")]
            public string Length { get; set; }
        
    }
}
