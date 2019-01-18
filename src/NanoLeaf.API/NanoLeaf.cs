using System;
using System.Runtime.CompilerServices;
using NanoLeaf.API.Contracts;
using System.Threading.Tasks;

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
        public Task<string> GetDeviceInformationAsync()
        {
            // TODO: Implement more complex structure
            return _apiContext.HttpClient.GetStringAsync(AuthorizationToken);
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