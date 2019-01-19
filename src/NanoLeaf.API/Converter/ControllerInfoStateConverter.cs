using NanoLeaf.API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;

namespace NanoLeaf.API.Converter
{
    internal class ControllerInfoStateConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ControllerInfoState);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = JObject.Load(reader);

            var state = new ControllerInfoState();
            serializer.Populate(obj.CreateReader(), state);
            state.IsPoweredOn = obj["on"]["value"].Value<bool>();

            return state;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var state = (ControllerInfoState) value;

            // Add isPoweredOn state like NanoLeaf
            var jObject = new JObject { { "on", new JObject { { "value", state.IsPoweredOn } } } };

            foreach (var prop in value.GetType().GetProperties())
            {
                if (!prop.CanRead)
                    continue;

                if (prop.GetCustomAttribute<JsonIgnoreAttribute>() != null)
                    continue;

                var propValue = prop.GetValue(value);
                if (propValue != null)
                {
                    jObject.Add(prop.Name, JToken.FromObject(propValue, serializer));
                }
            }

            jObject.WriteTo(writer);
        }
    }
}