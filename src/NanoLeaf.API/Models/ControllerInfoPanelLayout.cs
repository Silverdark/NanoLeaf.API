using Newtonsoft.Json;

namespace NanoLeaf.API.Models
{
    public class ControllerInfoPanelLayout
    {
        [JsonProperty("layout")]
        public PanelLayout Layout { get; set; }

        [JsonProperty("globalOrientation")]
        public ValueInformation GlobalOrientation { get; set; }
    }
}