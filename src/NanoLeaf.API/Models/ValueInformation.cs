using Newtonsoft.Json;

namespace NanoLeaf.API.Models
{
    public class ValueInformation
    {
        [JsonProperty("value")]
        public int CurrentValue { get; set; }

        [JsonProperty("max")]
        public int MaxValue { get; set; }

        [JsonProperty("min")]
        public int MinValue { get; set; }
    }
}