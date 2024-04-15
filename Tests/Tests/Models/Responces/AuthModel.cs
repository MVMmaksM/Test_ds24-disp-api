using System;
using Newtonsoft.Json;

namespace Tests.Models
{
   
    public class AuthModel
    {
        [JsonProperty(Required = Required.Always, PropertyName = "ok")]      
        public bool Ok { get; set; }
  
        [JsonProperty(Required = Required.Always, PropertyName = "credentials")]
        public bool Credentials { get; set; }
     
        [JsonProperty(Required = Required.Always, PropertyName = "msg")]
        public string Msg { get; set; }
  
        [JsonProperty(Required = Required.Always, PropertyName = "token")]
        public string Token { get; set; }
    }
}
