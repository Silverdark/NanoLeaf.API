using NanoLeaf.API.Tests.TestHelpers;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace NanoLeaf.API.Tests
{
    public class NanoLeafStateTests
    {
        private readonly HttpResponseMessage _responseMessage;
        private readonly NanoLeafState _nanoLeafState;

        public NanoLeafStateTests()
        {
            _responseMessage = new HttpResponseMessage();
            var httpClient = HttpClientHelper.GetClientWithCustomResponse(_responseMessage);

            var apiContext = new NanoLeafApiContext("token", httpClient);

            _nanoLeafState = new NanoLeafState(apiContext);
        }

        [Fact]
        public async Task GetPowerStateAsync_NanoLeafIsOn_ReturnsTrue()
        {
            // Arrange
            _responseMessage.Content = new StringContent("{'value': true}");

            // Act
            var powerState = await _nanoLeafState.GetPowerStateAsync();

            // Assert
            Assert.True(powerState);
        }

        [Fact]
        public async Task GetPowerStateAsync_NanoLeafIsOff_ReturnsOff()
        {
            // Arrange
            _responseMessage.Content = new StringContent("{'value': false}");

            // Act
            var powerState = await _nanoLeafState.GetPowerStateAsync();

            // Assert
            Assert.False(powerState);
        }

        [Fact]
        public async Task GetBrightnessAsync_Default_GetValues()
        {
            // Arrange
            _responseMessage.Content = new StringContent("{'value': 95, 'max': 100, 'min': 0}");

            // Act
            var brightness = await _nanoLeafState.GetBrightnessAsync();

            // Assert
            Assert.Equal(95, brightness.CurrentValue);
            Assert.Equal(100, brightness.MaxValue);
            Assert.Equal(0, brightness.MinValue);
        }

        [Fact]
        public async Task GetHueAsync_Default_GetValues()
        {
            // Arrange
            _responseMessage.Content = new StringContent("{'value': 95, 'max': 100, 'min': 0}");

            // Act
            var hue = await _nanoLeafState.GetHueAsync();

            // Assert
            Assert.Equal(95, hue.CurrentValue);
            Assert.Equal(100, hue.MaxValue);
            Assert.Equal(0, hue.MinValue);
        }

        [Fact]
        public async Task GetSaturationAsync_Default_GetValues()
        {
            // Arrange
            _responseMessage.Content = new StringContent("{'value': 95, 'max': 100, 'min': 0}");

            // Act
            var saturation = await _nanoLeafState.GetSaturationAsync();

            // Assert
            Assert.Equal(95, saturation.CurrentValue);
            Assert.Equal(100, saturation.MaxValue);
            Assert.Equal(0, saturation.MinValue);
        }

        [Fact]
        public async Task GetColorTemperatureAsync_Default_GetValues()
        {
            // Arrange
            _responseMessage.Content = new StringContent("{'value': 95, 'max': 100, 'min': 0}");

            // Act
            var colorTemperature = await _nanoLeafState.GetColorTemperatureAsync();

            // Assert
            Assert.Equal(95, colorTemperature.CurrentValue);
            Assert.Equal(100, colorTemperature.MaxValue);
            Assert.Equal(0, colorTemperature.MinValue);
        }

        [Fact]
        public async Task GetColorModeAsync_Default_GetValues()
        {
            // Arrange
            _responseMessage.Content = new StringContent("ct");

            // Act
            var colorMode = await _nanoLeafState.GetColorModeAsync();

            // Assert
            Assert.Equal("ct", colorMode);
        }
    }
}