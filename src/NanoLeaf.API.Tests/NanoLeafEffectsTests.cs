using NanoLeaf.API.Tests.TestHelpers;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace NanoLeaf.API.Tests
{
    public class NanoLeafEffectsTests
    {
        private const string AuthToken = "token";

        private readonly HttpResponseMessage _responseMessage;
        private readonly NanoLeafEffects _nanoLeafEffects;

        private HttpRequestMessage _requestMessage;

        public NanoLeafEffectsTests()
        {
            _responseMessage = new HttpResponseMessage();
            var httpClient = HttpClientHelper.GetMockedClient(_responseMessage, message => _requestMessage = message);

            var apiContext = new NanoLeafApiContext(AuthToken, httpClient);
            _nanoLeafEffects = new NanoLeafEffects(apiContext);
        }

        [Fact]
        public async Task GetCurrentEffectAsync_Default_ReturnValue()
        {
            // Arrange
            _responseMessage.Content = new StringContent("Fireworks");

            // Act
            var currentEffect = await _nanoLeafEffects.GetCurrentEffectAsync();

            // Assert
            Assert.Equal("Fireworks", currentEffect);

            Assert.Equal(HttpMethod.Get, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/effects/select", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task SetEffectAsync_Default_CorrectApiMessage()
        {
            // Act
            await _nanoLeafEffects.SetEffectAsync("Flames");

            // Assert
            Assert.Equal("{'select': 'Flames'}", await _requestMessage.Content.ReadAsStringAsync());

            Assert.Equal(HttpMethod.Put, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/effects", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task GetEffectListAsync_Default_ReturnValues()
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

            Assert.Equal(HttpMethod.Get, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/effects/effectsList", _requestMessage.RequestUri.AbsolutePath);
        }
    }
}