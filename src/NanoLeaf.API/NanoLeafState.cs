using System;
using System.Net.Http;
using System.Threading.Tasks;
using NanoLeaf.API.Contracts;
using NanoLeaf.API.Models;
using Newtonsoft.Json;

namespace NanoLeaf.API
{
    internal class NanoLeafState : INanoLeafState
    {
        private readonly NanoLeafApiContext _apiContext;

        public NanoLeafState(NanoLeafApiContext apiContext)
        {
            _apiContext = apiContext ?? throw new ArgumentNullException(nameof(apiContext));
        }

        /// <inheritdoc />
        public async Task<bool> GetPowerStateAsync()
        {
            var content = await _apiContext.HttpClient.GetStringAsync($"{_apiContext.AuthToken}/state/on");
            dynamic jsonData = JsonConvert.DeserializeObject(content);

            return jsonData["value"];
        }

        /// <inheritdoc />
        public Task SetPowerStateAsync(bool state)
        {
            var bodyContent = "{'on': {'value': '" + state + "'}}";
            var body = new StringContent(bodyContent);

            return _apiContext.HttpClient.PutAsync($"{_apiContext.AuthToken}/state", body);
        }

        /// <inheritdoc />
        public async Task<ValueInformation> GetBrightnessAsync()
        {
            var content = await _apiContext.HttpClient.GetStringAsync($"{_apiContext.AuthToken}/state/brightness");
            dynamic jsonData = JsonConvert.DeserializeObject(content);

            return new ValueInformation((int) jsonData["value"], (int) jsonData["max"], (int) jsonData["min"]);
        }

        /// <inheritdoc />
        public Task SetBrightnessAsync(int brightness, int duration = -1)
        {
            var bodyContent = "{'brightness': {'value': " + brightness + "}}";
            if (duration > -1)
                bodyContent = "{'brightness': {'value': " + brightness + ", 'duration': " + duration + "}}";

            var body = new StringContent(bodyContent);

            return _apiContext.HttpClient.PutAsync($"{_apiContext.AuthToken}/state", body);
        }

        /// <inheritdoc />
        public async Task<ValueInformation> GetHueAsync()
        {
            var content = await _apiContext.HttpClient.GetStringAsync($"{_apiContext.AuthToken}/state/hue");
            dynamic jsonData = JsonConvert.DeserializeObject(content);

            return new ValueInformation((int) jsonData["value"], (int) jsonData["max"], (int) jsonData["min"]);
        }

        /// <inheritdoc />
        public Task SetHueAsync(int hue)
        {
            var bodyContent = "{'hue': {'value': " + hue + "}}";
            var body = new StringContent(bodyContent);

            return _apiContext.HttpClient.PutAsync($"{_apiContext.AuthToken}/state", body);
        }

        /// <inheritdoc />
        public async Task<ValueInformation> GetSaturationAsync()
        {
            var content = await _apiContext.HttpClient.GetStringAsync($"{_apiContext.AuthToken}/state/sat");
            dynamic jsonData = JsonConvert.DeserializeObject(content);

            return new ValueInformation((int) jsonData["value"], (int) jsonData["max"], (int) jsonData["min"]);
        }

        /// <inheritdoc />
        public Task SetSaturationAsync(int saturation)
        {
            var bodyContent = "{'sat': {'value': " + saturation + "}}";
            var body = new StringContent(bodyContent);

            return _apiContext.HttpClient.PutAsync($"{_apiContext.AuthToken}/state", body);
        }

        /// <inheritdoc />
        public async Task<ValueInformation> GetColorTemperatureAsync()
        {
            var content = await _apiContext.HttpClient.GetStringAsync($"{_apiContext.AuthToken}/state/ct");
            dynamic jsonData = JsonConvert.DeserializeObject(content);

            return new ValueInformation((int) jsonData["value"], (int) jsonData["max"], (int) jsonData["min"]);
        }

        /// <inheritdoc />
        public Task SetColorTemperatureAsync(int colorTemperature)
        {
            var bodyContent = "{'ct': {'value': " + colorTemperature + "}}";
            var body = new StringContent(bodyContent);

            return _apiContext.HttpClient.PutAsync($"{_apiContext.AuthToken}/state", body);
        }

        /// <inheritdoc />
        public Task<string> GetColorModeAsync()
        {
            return _apiContext.HttpClient.GetStringAsync($"{_apiContext.AuthToken}/state/colorMode");
        }
    }
}