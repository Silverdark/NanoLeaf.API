using NanoLeaf.API.Contracts;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NanoLeaf.API
{
    public class NanoLeafFactory : INanoLeafFactory
    {
        private readonly HttpClient _httpClient;

        public NanoLeafFactory(string ipAddress, int port = 16021, string basePath = "api/v1/") 
        {
            _httpClient = new HttpClient { BaseAddress = new Uri($"http://{ipAddress}:{port}/{basePath}") };
        }

        public NanoLeafFactory(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <inheritdoc />
        public async Task<INanoLeaf> CreateNanoLeafAsync()
        {
            var authorizationToken = await CreateAuthorizationTokenAsync();
            var apiContext = new NanoLeafApiContext(authorizationToken, _httpClient);
            return new NanoLeaf(apiContext);
        }

        /// <inheritdoc />
        public INanoLeaf CreateNanoLeaf(string authorizationToken)
        {
            var apiContext = new NanoLeafApiContext(authorizationToken, _httpClient);
            return new NanoLeaf(apiContext);
        }

        private async Task<string> CreateAuthorizationTokenAsync()
        {
            var response = await _httpClient.PostAsync("new", null);
            var content = await response.Content.ReadAsStringAsync();
            dynamic jsonData = JsonConvert.DeserializeObject(content);

            return jsonData["auth_token"];
        }
    }
}