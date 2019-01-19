using NanoLeaf.API.Converter;
using Newtonsoft.Json;

namespace NanoLeaf.API.Models
{
    [JsonConverter(typeof(ControllerInfoStateConverter))]
    public class ControllerInfoState
    {
        [JsonIgnore]
        public bool IsPoweredOn { get; set; }

        [JsonProperty("brightness")]
        public ValueInformation Brightness { get; set; }

        [JsonProperty("hue")]
        public ValueInformation Hue { get; set; }

        [JsonProperty("sat")]
        public ValueInformation Saturation { get; set; }

        [JsonProperty("ct")]
        public ValueInformation ColorTemperature { get; set; }

        [JsonProperty("colorMode")]
        public string ColorMode { get; set; }
    }
}