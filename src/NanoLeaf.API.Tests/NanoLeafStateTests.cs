using NanoLeaf.API.Tests.TestHelpers;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace NanoLeaf.API.Tests
{
    public class NanoLeafStateTests
    {
        private const string AuthToken = "token";

        private readonly HttpResponseMessage _responseMessage;
        private readonly NanoLeafState _nanoLeafState;

        private HttpRequestMessage _requestMessage;

        public NanoLeafStateTests()
        {
            _responseMessage = new HttpResponseMessage();
            var httpClient = HttpClientHelper.GetMockedClient(_responseMessage, message => _requestMessage = message);

            var apiContext = new NanoLeafApiContext(AuthToken, httpClient);
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

            Assert.Equal(HttpMethod.Get, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/state/on", _requestMessage.RequestUri.AbsolutePath);
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

            Assert.Equal(HttpMethod.Get, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/state/on", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task SetPowerStateAsync_SetPowerOn_CorrectApiMessage()
        {
            // Act
            await _nanoLeafState.SetPowerStateAsync(true);

            // Assert
            Assert.Equal("{'on': {'value': true}}", await _requestMessage.Content.ReadAsStringAsync());

            Assert.Equal(HttpMethod.Put, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/state", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task SetPowerStateAsync_SetPowerOff_CorrectApiMessage()
        {
            // Act
            await _nanoLeafState.SetPowerStateAsync(false);

            // Assert
            Assert.Equal("{'on': {'value': false}}", await _requestMessage.Content.ReadAsStringAsync());

            Assert.Equal(HttpMethod.Put, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/state", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task GetBrightnessAsync_Default_ReturnValues()
        {
            // Arrange
            _responseMessage.Content = new StringContent("{'value': 95, 'max': 100, 'min': 0}");

            // Act
            var brightness = await _nanoLeafState.GetBrightnessAsync();

            // Assert
            Assert.Equal(95, brightness.CurrentValue);
            Assert.Equal(100, brightness.MaxValue);
            Assert.Equal(0, brightness.MinValue);

            Assert.Equal(HttpMethod.Get, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/state/brightness", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task SetBrightnessAsync_BrightnessWithDuration_CorrectApiMessage()
        {
            // Act
            await _nanoLeafState.SetBrightnessAsync(125, 20);

            // Assert
            Assert.Equal("{'brightness': {'value': 125, 'duration': 20}}", await _requestMessage.Content.ReadAsStringAsync());

            Assert.Equal(HttpMethod.Put, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/state", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task SetBrightnessAsync_BrightnessWithoutDuration_CorrectApiMessage()
        {
            // Act
            await _nanoLeafState.SetBrightnessAsync(125);

            // Assert
            Assert.Equal("{'brightness': {'value': 125}}", await _requestMessage.Content.ReadAsStringAsync());

            Assert.Equal(HttpMethod.Put, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/state", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task GetHueAsync_Default_ReturnValues()
        {
            // Arrange
            _responseMessage.Content = new StringContent("{'value': 95, 'max': 100, 'min': 0}");

            // Act
            var hue = await _nanoLeafState.GetHueAsync();

            // Assert
            Assert.Equal(95, hue.CurrentValue);
            Assert.Equal(100, hue.MaxValue);
            Assert.Equal(0, hue.MinValue);

            Assert.Equal(HttpMethod.Get, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/state/hue", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task SetHueAsync_WithHueValue_CorrectApiMessage()
        {
            // Act
            await _nanoLeafState.SetHueAsync(123);

            // Assert
            Assert.Equal("{'hue': {'value': 123}}", await _requestMessage.Content.ReadAsStringAsync());

            Assert.Equal(HttpMethod.Put, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/state", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task GetSaturationAsync_Default_ReturnValues()
        {
            // Arrange
            _responseMessage.Content = new StringContent("{'value': 95, 'max': 100, 'min': 0}");

            // Act
            var saturation = await _nanoLeafState.GetSaturationAsync();

            // Assert
            Assert.Equal(95, saturation.CurrentValue);
            Assert.Equal(100, saturation.MaxValue);
            Assert.Equal(0, saturation.MinValue);

            Assert.Equal(HttpMethod.Get, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/state/sat", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task SetSaturationAsync_WithSaturationValue_CorrectApiMessage()
        {
            // Act
            await _nanoLeafState.SetSaturationAsync(321);

            // Assert
            Assert.Equal("{'sat': {'value': 321}}", await _requestMessage.Content.ReadAsStringAsync());

            Assert.Equal(HttpMethod.Put, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/state", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task GetColorTemperatureAsync_Default_ReturnValues()
        {
            // Arrange
            _responseMessage.Content = new StringContent("{'value': 95, 'max': 100, 'min': 0}");

            // Act
            var colorTemperature = await _nanoLeafState.GetColorTemperatureAsync();

            // Assert
            Assert.Equal(95, colorTemperature.CurrentValue);
            Assert.Equal(100, colorTemperature.MaxValue);
            Assert.Equal(0, colorTemperature.MinValue);

            Assert.Equal(HttpMethod.Get, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/state/ct", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task SetColorTemperatureAsync_WithColorTemperatureValue_CorrectApiMessage()
        {
            // Act
            await _nanoLeafState.SetColorTemperatureAsync(4000);

            // Assert
            Assert.Equal("{'ct': {'value': 4000}}", await _requestMessage.Content.ReadAsStringAsync());

            Assert.Equal(HttpMethod.Put, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/state", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task GetColorModeAsync_Default_ReturnValues()
        {
            // Arrange
            _responseMessage.Content = new StringContent("ct");

            // Act
            var colorMode = await _nanoLeafState.GetColorModeAsync();

            // Assert
            Assert.Equal("ct", colorMode);

            Assert.Equal(HttpMethod.Get, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/state/colorMode", _requestMessage.RequestUri.AbsolutePath);
        }
    }
}