using NanoLeaf.API.Tests.TestHelpers;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NanoLeaf.API.Tests
{
    public class NanoLeafStateTests
    {
        private readonly HttpResponseMessage _responseMessage;
        private readonly NanoLeafState _nanoLeafState;

        private string _apiMessage;

        public NanoLeafStateTests()
        {
            _responseMessage = new HttpResponseMessage();
            var httpClient = HttpClientHelper.GetClientWithCustomResponse(_responseMessage);

            Action<HttpRequestMessage, CancellationToken> callback 
                = async (message, token) => _apiMessage = await message.Content.ReadAsStringAsync();
            HttpClientHelper.SetSendAsyncCallback(httpClient, callback);

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
        public async Task SetPowerStateAsync_SetPowerOn_CorrectApiMessage()
        {
            // Act
            await _nanoLeafState.SetPowerStateAsync(true);

            // Assert
            Assert.Equal("{'on': {'value': true}}", _apiMessage);
        }

        [Fact]
        public async Task SetPowerStateAsync_SetPowerOff_CorrectApiMessage()
        {
            // Act
            await _nanoLeafState.SetPowerStateAsync(false);

            // Assert
            Assert.Equal("{'on': {'value': false}}", _apiMessage);
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
        public async Task SetBrightnessAsync_BrightnessWithDuration_CorrectApiMessage()
        {
            // Act
            await _nanoLeafState.SetBrightnessAsync(125, 20);

            // Assert
            Assert.Equal("{'brightness': {'value': 125, 'duration': 20}}", _apiMessage);
        }

        [Fact]
        public async Task SetBrightnessAsync_BrightnessWithoutDuration_CorrectApiMessage()
        {
            // Act
            await _nanoLeafState.SetBrightnessAsync(125);

            // Assert
            Assert.Equal("{'brightness': {'value': 125}}", _apiMessage);
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
        public async Task SetHueAsync_WithHueValue_CorrectApiMessage()
        {
            // Act
            await _nanoLeafState.SetHueAsync(123);

            // Assert
            Assert.Equal("{'hue': {'value': 123}}", _apiMessage);
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
        public async Task SetSaturationAsync_WithSaturationValue_CorrectApiMessage()
        {
            // Act
            await _nanoLeafState.SetSaturationAsync(321);

            // Assert
            Assert.Equal("{'sat': {'value': 321}}", _apiMessage);
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
        public async Task SetColorTemperatureAsync_WithColorTemperatureValue_CorrectApiMessage()
        {
            // Act
            await _nanoLeafState.SetColorTemperatureAsync(4000);

            // Assert
            Assert.Equal("{'ct': {'value': 4000}}", _apiMessage);
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