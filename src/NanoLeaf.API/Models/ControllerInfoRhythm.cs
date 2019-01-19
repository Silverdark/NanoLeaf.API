using Newtonsoft.Json;

namespace NanoLeaf.API.Models
{
    public class ControllerInfoRhythm
    {
        [JsonProperty("rhythmConnected")]
        public bool IsConnected { get; set; }

        [JsonProperty("rhythmActive")]
        public bool? IsActive { get; set; }

        [JsonProperty("rhythmId")]
        public string Id { get; set; }

        [JsonProperty("hardwareVersion")]
        public string HardwareVersion { get; set; }

        [JsonProperty("firmwareVersion")]
        public string FirmwareVersion { get; set; }

        [JsonProperty("auxAvailable")]
        public bool? IsAuxCableAvailable { get; set; }

        [JsonProperty("rhythmMode")]
        public int? RhythmMode { get; set; }

        [JsonProperty("rhythmPos")]
        public PositionOrientation Position { get; set; }
    }
}