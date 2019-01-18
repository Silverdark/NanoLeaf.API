using Newtonsoft.Json;

namespace NanoLeaf.API.Models
{
    public class PositionOrientation
    {
        public PositionOrientation(int x, int y, int orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }

        [JsonProperty("x")]
        public int X { get; }

        [JsonProperty("y")]
        public int Y { get; }

        [JsonProperty("o")]
        public int Orientation { get; }
    }
}