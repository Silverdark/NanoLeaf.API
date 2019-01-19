using Newtonsoft.Json;

namespace NanoLeaf.API.Models
{
    public class PanelLayout
    {
        [JsonProperty("numPanels")]
        public int NumberOfPanels { get; set; }

        [JsonProperty("sideLength")]
        public int SideLength { get; set; }

        [JsonProperty("positionData")]
        public PanelPosition[] PanelPositions { get; set; }
    }
}