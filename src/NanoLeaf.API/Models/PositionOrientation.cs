using Newtonsoft.Json;

namespace NanoLeaf.API.Models
{
    public class PositionOrientation
    {
        [JsonProperty("x")]
        public int X { get; set; }

        [JsonProperty("y")]
        public int Y { get; set; }

        [JsonProperty("o")]
        public int Orientation { get; set; }
    }
}