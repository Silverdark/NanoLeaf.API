using NanoLeaf.API.Contracts;
using NanoLeaf.API.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NanoLeaf.API
{
    internal class NanoLeafRhythm : INanoLeafRhythm
    {
        private readonly NanoLeafApiContext _apiContext;

        public NanoLeafRhythm(NanoLeafApiContext apiContext)
        {
            _apiContext = apiContext ?? throw new ArgumentNullException(nameof(apiContext));
        }

        /// <inheritdoc />
        public async Task<bool> IsConnectedAsync()
        {
            var content = await _apiContext.HttpClient.GetStringAsync($"{_apiContext.AuthToken}/rhythm/rhythmConnected");
            return bool.Parse(content);
        }

        /// <inheritdoc />
        public async Task<bool> IsActiveAsync()
        {
            var content = await _apiContext.HttpClient.GetStringAsync($"{_apiContext.AuthToken}/rhythm/rhythmActive");
            return bool.Parse(content);
        }

        /// <inheritdoc />
        public async Task<int> GetIdAsync()
        {
            var content = await _apiContext.HttpClient.GetStringAsync($"{_apiContext.AuthToken}/rhythm/rhythmId");
            return int.Parse(content);
        }

        /// <inheritdoc />
        public Task<string> GetHardwareVersionAsync()
        {
            return _apiContext.HttpClient.GetStringAsync($"{_apiContext.AuthToken}/rhythm/hardwareVersion");
        }

        /// <inheritdoc />
        public Task<string> GetFirmwareVersionAsync()
        {
            return _apiContext.HttpClient.GetStringAsync($"{_apiContext.AuthToken}/rhythm/firmwareVersion");
        }

        /// <inheritdoc />
        public async Task<PositionOrientation> GetPositionAsync()
        {
            var content = await _apiContext.HttpClient.GetStringAsync($"{_apiContext.AuthToken}/rhythm/rhythmPos");
            return JsonConvert.DeserializeObject<PositionOrientation>(content);
        }

        /// <inheritdoc />
        public async Task<bool> UsesMicrophoneAsync()
        {
            return await GetRhythmModeAsync() == 0;
        }

        /// <inheritdoc />
        public Task SetUseMicrophoneAsync()
        {
            return SetRhythmModeAsync(0);
        }

        /// <inheritdoc />
        public async Task<bool> IsAuxCableAvailableAsync()
        {
            var content = await _apiContext.HttpClient.GetStringAsync($"{_apiContext.AuthToken}/rhythm/auxAvailable");
            return bool.Parse(content);
        }

        /// <inheritdoc />
        public async Task<bool> UsesAuxCableAsync()
        {
            return await GetRhythmModeAsync() == 1;
        }

        /// <inheritdoc />
        public Task SetUseAuxCableAsync()
        {
            return SetRhythmModeAsync(1);
        }

        private async Task<int> GetRhythmModeAsync()
        {
            var content = await _apiContext.HttpClient.GetStringAsync($"{_apiContext.AuthToken}/rhythm/rhythmMode");
            return int.Parse(content);
        }

        private async Task SetRhythmModeAsync(int mode)
        {
            var bodyContent = "{'rhythmMode': " + mode + "}";
            var body = new StringContent(bodyContent);

            await _apiContext.HttpClient.PutAsync($"{_apiContext.AuthToken}/rhythm/rhythmMode", body);
        }
    }
}