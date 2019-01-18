using NanoLeaf.API.Tests.TestHelpers;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NanoLeaf.API.Tests
{
    public class NanoLeafEffectsTests
    {
        private readonly HttpResponseMessage _responseMessage;
        private readonly NanoLeafEffects _nanoLeafEffects;

        private string _apiMessage;

        public NanoLeafEffectsTests()
        {
            _responseMessage = new HttpResponseMessage();
            var httpClient = HttpClientHelper.GetClientWithCustomResponse(_responseMessage);

            Action<HttpRequestMessage, CancellationToken> callback
                = async (message, token) => _apiMessage = await message.Content.ReadAsStringAsync();
            HttpClientHelper.SetSendAsyncCallback(httpClient, callback);

            var apiContext = new NanoLeafApiContext("token", httpClient);
            _nanoLeafEffects = new NanoLeafEffects(apiContext);
        }

        [Fact]
        public async Task GetCurrentEffectAsync_Default_GetValue()
        {
            // Arrange
            _responseMessage.Content = new StringContent("Fireworks");

            // Act
            var currentEffect = await _nanoLeafEffects.GetCurrentEffectAsync();

            // Assert
            Assert.Equal("Fireworks", currentEffect);
        }

        [Fact]
        public async Task SetEffectAsync_Default_CorrectApiMessage()
        {
            // Act
            await _nanoLeafEffects.SetEffectAsync("Flames");

            // Assert
            Assert.Equal("{'select': 'Flames'}", _apiMessage);
        }

        [Fact]
        public async Task GetEffectListAsync_Default_GetValues()
        {
            // Arrange
            string[] effectList =
            {
                "Color Burst",
                "Fireworks",
                "Flames"
            };

            _responseMessage.Content = new StringContent(JsonConvert.SerializeObject(effectList));

            // Act
            var currentEffectList = await _nanoLeafEffects.GetEffectListAsync();

            // Assert
            Assert.Equal(3, currentEffectList.Length);
            Assert.Contains("Color Burst", currentEffectList);
            Assert.Contains("Fireworks", currentEffectList);
            Assert.Contains("Flames", currentEffectList);
        }
    }
}