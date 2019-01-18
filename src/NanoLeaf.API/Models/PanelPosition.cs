using Newtonsoft.Json;

namespace NanoLeaf.API.Models
{
    public class PanelPosition
    {
        public PanelPosition(int panelId, int x, int y, int orientation)
        {
            PanelId = panelId;
            X = x;
            Y = y;
            Orientation = orientation;
        }

        [JsonProperty("panelId")]
        public int PanelId { get; }

        [JsonProperty("x")]
        public int X { get; }

        [JsonProperty("y")]
        public int Y { get; }

        [JsonProperty("o")]
        public int Orientation { get; }
    }
}