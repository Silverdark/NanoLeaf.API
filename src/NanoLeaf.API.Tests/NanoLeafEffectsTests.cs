using NanoLeaf.API.Tests.TestHelpers;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace NanoLeaf.API.Tests
{
    public class NanoLeafEffectsTests
    {
        private readonly HttpResponseMessage _responseMessage;
        private readonly NanoLeafEffects _nanoLeafEffects;

        public NanoLeafEffectsTests()
        {
            _responseMessage = new HttpResponseMessage();
            var httpClient = HttpClientHelper.GetClientWithCustomResponse(_responseMessage);

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