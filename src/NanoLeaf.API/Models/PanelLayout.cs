using Newtonsoft.Json;

namespace NanoLeaf.API.Models
{
    public class PanelLayout
    {
        public PanelLayout(int numberOfPanels, int sideLength, PanelPosition[] panelPositions)
        {
            NumberOfPanels = numberOfPanels;
            SideLength = sideLength;
            PanelPositions = panelPositions;
        }

        [JsonProperty("numPanels")]
        public int NumberOfPanels { get; }

        [JsonProperty("sideLength")]
        public int SideLength { get; }

        [JsonProperty("positionData")]
        public PanelPosition[] PanelPositions { get; }
    }
}