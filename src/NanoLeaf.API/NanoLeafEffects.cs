using NanoLeaf.API.Contracts;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NanoLeaf.API
{
    internal class NanoLeafEffects : INanoLeafEffects
    {
        private readonly NanoLeafApiContext _apiContext;

        public NanoLeafEffects(NanoLeafApiContext apiContext)
        {
            _apiContext = apiContext ?? throw new ArgumentNullException(nameof(apiContext));
        }

        /// <inheritdoc />
        public Task<string> GetCurrentEffectAsync()
        {
            return _apiContext.HttpClient.GetStringAsync($"{_apiContext.AuthToken}/effects/select");
        }

        /// <inheritdoc />
        public Task SetEffectAsync(string effectName)
        {
            var bodyContent = "{'select': '" + effectName + "'}";
            var body = new StringContent(bodyContent);

            return _apiContext.HttpClient.PutAsync($"{_apiContext.AuthToken}/effects", body);
        }

        /// <inheritdoc />
        public async Task<string[]> GetEffectListAsync()
        {
            var content = await _apiContext.HttpClient.GetStringAsync($"{_apiContext.AuthToken}/effects/effectsList");
            return JsonConvert.DeserializeObject<string[]>(content);
        }
    }
}