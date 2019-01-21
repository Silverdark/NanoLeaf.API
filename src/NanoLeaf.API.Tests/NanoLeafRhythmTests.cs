using NanoLeaf.API.Tests.TestHelpers;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace NanoLeaf.API.Tests
{
    public class NanoLeafRhythmTests
    {
        private const string AuthToken = "token";

        private readonly HttpResponseMessage _responseMessage;
        private readonly NanoLeafRhythm _nanoLeafRhythm;

        private HttpRequestMessage _requestMessage;

        public NanoLeafRhythmTests()
        {
            _responseMessage = new HttpResponseMessage();
            var httpClient = HttpClientHelper.GetMockedClient(_responseMessage, message => _requestMessage = message);

            var apiContext = new NanoLeafApiContext(AuthToken, httpClient);
            _nanoLeafRhythm = new NanoLeafRhythm(apiContext);
        }

        [Fact]
        public async Task IsConnectedAsync_RhythmConnected_ReturnsTrue()
        {
            // Arrange
            _responseMessage.Content = new StringContent("true");

            // Act
            var isConnected = await _nanoLeafRhythm.IsConnectedAsync();

            // Assert
            Assert.True(isConnected);

            Assert.Equal(HttpMethod.Get, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/rhythm/rhythmConnected", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task IsConnectedAsync_RhythmNotConnected_ReturnsFalse()
        {
            // Arrange
            _responseMessage.Content = new StringContent("false");

            // Act
            var isConnected = await _nanoLeafRhythm.IsConnectedAsync();

            // Assert
            Assert.False(isConnected);

            Assert.Equal(HttpMethod.Get, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/rhythm/rhythmConnected", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task IsActiveAsync_RhythmIsActive_ReturnsTrue()
        {
            // Arrange
            _responseMessage.Content = new StringContent("true");

            // Act
            var isConnected = await _nanoLeafRhythm.IsActiveAsync();

            // Assert
            Assert.True(isConnected);

            Assert.Equal(HttpMethod.Get, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/rhythm/rhythmActive", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task IsActiveAsync_RhythmIsNotActive_ReturnsFalse()
        {
            // Arrange
            _responseMessage.Content = new StringContent("false");

            // Act
            var isConnected = await _nanoLeafRhythm.IsActiveAsync();

            // Assert
            Assert.False(isConnected);

            Assert.Equal(HttpMethod.Get, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/rhythm/rhythmActive", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task GetIdAsync_Default_ReturnsId()
        {
            // Arrange
            _responseMessage.Content = new StringContent("123");

            // Act
            var id = await _nanoLeafRhythm.GetIdAsync();

            // Assert
            Assert.Equal(123, id);

            Assert.Equal(HttpMethod.Get, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/rhythm/rhythmId", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task GetHardwareVersionAsync_Default_ReturnsHardwareVersion()
        {
            // Arrange
            _responseMessage.Content = new StringContent("1.4");

            // Act
            var hardwareVersion = await _nanoLeafRhythm.GetHardwareVersionAsync();

            // Assert
            Assert.Equal("1.4", hardwareVersion);

            Assert.Equal(HttpMethod.Get, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/rhythm/hardwareVersion", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task GetFirmwareVersionAsync_Default_ReturnsFirmwareVersion()
        {
            // Arrange
            _responseMessage.Content = new StringContent("2.0");

            // Act
            var firmwareVersion = await _nanoLeafRhythm.GetFirmwareVersionAsync();

            // Assert
            Assert.Equal("2.0", firmwareVersion);

            Assert.Equal(HttpMethod.Get, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/rhythm/firmwareVersion", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task GetPositionAsync_Default_ReturnsPosition()
        {
            // Arrange
            _responseMessage.Content = new StringContent("{'x': 0, 'y': 173, 'o': 60}");

            // Act
            var position = await _nanoLeafRhythm.GetPositionAsync();

            // Assert
            Assert.Equal(0, position.X);
            Assert.Equal(173, position.Y);
            Assert.Equal(60, position.Orientation);

            Assert.Equal(HttpMethod.Get, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/rhythm/rhythmPos", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task UsesMicrophoneAsync_UsesMicrophone_ReturnsTrue()
        {
            // Arrange
            _responseMessage.Content = new StringContent("0");

            // Act
            var usesMicrophone = await _nanoLeafRhythm.UsesMicrophoneAsync();

            // Assert
            Assert.True(usesMicrophone);

            Assert.Equal(HttpMethod.Get, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/rhythm/rhythmMode", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task SetUseMicrophoneAsync_UseMicrophone_CorrectApiMessage()
        {
            // Act
            await _nanoLeafRhythm.SetUseMicrophoneAsync();

            // Assert
            Assert.Equal("{'rhythmMode': 0}", await _requestMessage.Content.ReadAsStringAsync());

            Assert.Equal(HttpMethod.Put, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/rhythm/rhythmMode", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task UsesMicrophoneAsync_UsesAuxCable_ReturnsFalse()
        {
            // Arrange
            _responseMessage.Content = new StringContent("1");

            // Act
            var usesMicrophone = await _nanoLeafRhythm.UsesMicrophoneAsync();

            // Assert
            Assert.False(usesMicrophone);

            Assert.Equal(HttpMethod.Get, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/rhythm/rhythmMode", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task IsAuxCableAvailableAsync_IsAuxAvailable_ReturnsTrue()
        {
            // Arrange
            _responseMessage.Content = new StringContent("true");

            // Act
            var auxAvailable = await _nanoLeafRhythm.IsAuxCableAvailableAsync();

            // Assert
            Assert.True(auxAvailable);

            Assert.Equal(HttpMethod.Get, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/rhythm/auxAvailable", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task IsAuxCableAvailableAsync_IsAuxNotAvailable_ReturnsFalse()
        {
            // Arrange
            _responseMessage.Content = new StringContent("false");

            // Act
            var auxAvailable = await _nanoLeafRhythm.IsAuxCableAvailableAsync();

            // Assert
            Assert.False(auxAvailable);

            Assert.Equal(HttpMethod.Get, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/rhythm/auxAvailable", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task UsesAuxCableAsync_UsesAuxCable_ReturnsTrue()
        {
            // Arrange
            _responseMessage.Content = new StringContent("1");

            // Act
            var usesAuxCable = await _nanoLeafRhythm.UsesAuxCableAsync();

            // Assert
            Assert.True(usesAuxCable);

            Assert.Equal(HttpMethod.Get, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/rhythm/rhythmMode", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task UsesAuxCableAsync_UsesMicrophone_ReturnsFalse()
        {
            // Arrange
            _responseMessage.Content = new StringContent("0");

            // Act
            var usesAuxCable = await _nanoLeafRhythm.UsesAuxCableAsync();

            // Assert
            Assert.False(usesAuxCable);

            Assert.Equal(HttpMethod.Get, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/rhythm/rhythmMode", _requestMessage.RequestUri.AbsolutePath);
        }

        [Fact]
        public async Task SetUseAuxCableAsync_UseAuxCable_CorrectApiMessage()
        {
            // Act
            await _nanoLeafRhythm.SetUseAuxCableAsync();

            // Assert
            Assert.Equal("{'rhythmMode': 1}", await _requestMessage.Content.ReadAsStringAsync());

            Assert.Equal(HttpMethod.Put, _requestMessage.Method);
            Assert.Equal($"/api/v1/{AuthToken}/rhythm/rhythmMode", _requestMessage.RequestUri.AbsolutePath);
        }
    }
}