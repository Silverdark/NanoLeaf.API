using Newtonsoft.Json;

namespace NanoLeaf.API.Models
{
    public class ValueInformation
    {
        public ValueInformation(int currentValue, int maxValue, int minValue)
        {
            CurrentValue = currentValue;
            MaxValue = maxValue;
            MinValue = minValue;
        }

        [JsonProperty("value")]
        public int CurrentValue { get; }

        [JsonProperty("max")]
        public int MaxValue { get; }

        [JsonProperty("min")]
        public int MinValue { get; }
    }
}