using NanoLeaf.API.Contracts;
using NanoLeaf.API.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NanoLeaf.API
{
    internal class NanoLeafPanelLayout : INanoLeafPanelLayout
    {
        private readonly NanoLeafApiContext _apiContext;

        public NanoLeafPanelLayout(NanoLeafApiContext apiContext)
        {
            _apiContext = apiContext ?? throw new ArgumentNullException(nameof(apiContext));
        }

        /// <inheritdoc />
        public async Task<ValueInformation> GetGlobalPanelOrientationAsync()
        {
            var content = await _apiContext.HttpClient.GetStringAsync($"{_apiContext.AuthToken}/panelLayout/globalOrientation");
            return JsonConvert.DeserializeObject<ValueInformation>(content);
        }

        /// <inheritdoc />
        public Task SetGlobalPanelOrientationAsync(int globalOrientation)
        {
            var bodyContent = "{'globalOrientation': {'value': " + globalOrientation + "}}";
            var body = new StringContent(bodyContent);

            return _apiContext.HttpClient.PutAsync($"{_apiContext.AuthToken}/panelLayout", body);
        }

        /// <inheritdoc />
        public async Task<PanelLayout> GetPanelLayoutAsync()
        {
            var content = await _apiContext.HttpClient.GetStringAsync($"{_apiContext.AuthToken}/panelLayout/layout");
            return JsonConvert.DeserializeObject<PanelLayout>(content);
        }
    }
}