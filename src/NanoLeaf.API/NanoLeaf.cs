using NanoLeaf.API.Contracts;
using NanoLeaf.API.Models;
using Newtonsoft.Json;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

// Only single time in assembly necessary
[assembly: InternalsVisibleTo("NanoLeaf.API.Tests")]

namespace NanoLeaf.API
{
    internal class NanoLeaf : INanoLeaf
    {
        private readonly NanoLeafApiContext _apiContext;

        internal NanoLeaf(NanoLeafApiContext apiContext)
        {
            _apiContext = apiContext ?? throw new ArgumentNullException(nameof(apiContext));

            State = new NanoLeafState(_apiContext);
            Effects = new NanoLeafEffects(_apiContext);
            PanelLayout = new NanoLeafPanelLayout(_apiContext);
            Rhythm = new NanoLeafRhythm(_apiContext);
        }

        /// <inheritdoc />
        public string AuthorizationToken => _apiContext.AuthToken;

        /// <inheritdoc />
        public INanoLeafState State { get; }

        /// <inheritdoc />
        public INanoLeafEffects Effects { get; }

        /// <inheritdoc />
        public INanoLeafPanelLayout PanelLayout { get; }

        /// <inheritdoc />
        public INanoLeafRhythm Rhythm { get; }

        /// <inheritdoc />
        public async Task<ControllerInfo> GetDeviceInformationAsync()
        {
            var content = await _apiContext.HttpClient.GetStringAsync(AuthorizationToken);
            return JsonConvert.DeserializeObject<ControllerInfo>(content);
        }

        /// <inheritdoc />
        public Task RevokeAuthorizationTokenAsync()
        {
            return _apiContext.HttpClient.DeleteAsync($"{AuthorizationToken}");
        }

        /// <inheritdoc />
        public Task IdentifyPanelAsync()
        {
            return _apiContext.HttpClient.PutAsync($"{AuthorizationToken}/identify", null);
        }
    }
}