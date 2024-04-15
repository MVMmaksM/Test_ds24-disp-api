using System;
using Newtonsoft.Json;

namespace Tests.Models.Responces
{
    public class EntityCntList
    {
        [JsonProperty(Required = Required.Always, PropertyName = "cnt")]
        public string Cnt { get; set; }

        [JsonProperty(Required = Required.Always, PropertyName = "cnt_id")]
        public int CntId { get; set; }

        [JsonProperty(Required = Required.Always, PropertyName = "account_id")]
        public int AccountId { get; set; }

        [JsonProperty(Required = Required.AllowNull, PropertyName = "callback_phone")]
        public string CallbackPhone { get; set; }

        [JsonProperty(Required = Required.AllowNull, PropertyName = "support_phone")]
        public string SupportPhone { get; set; }
    }
}
