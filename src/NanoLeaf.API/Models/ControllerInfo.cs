using Newtonsoft.Json;

namespace NanoLeaf.API.Models
{
    public class ControllerInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("serialNo")]
        public string SerialNumber { get; set; }

        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonProperty("firmwareVersion")]
        public string FirmwareVersion { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("state")]
        public ControllerInfoState State { get; set; }

        [JsonProperty("effects")]
        public ControllerInfoEffects Effects { get; set; }

        [JsonProperty("panelLayout")]
        public ControllerInfoPanelLayout PanelLayout { get; set; }

        [JsonProperty("rhythm")]
        public ControllerInfoRhythm Rhythm { get; set; }
    }
}