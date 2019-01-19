using Newtonsoft.Json;

namespace NanoLeaf.API.Models
{
    public class ControllerInfoEffects
    {
        [JsonProperty("select")]
        public string CurrentEffect { get; set; }

        [JsonProperty("effectsList")]
        public string[] EffectsList { get; set; }
    }
}