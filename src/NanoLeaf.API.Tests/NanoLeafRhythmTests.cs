using NanoLeaf.API.Tests.TestHelpers;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace NanoLeaf.API.Tests
{
    public class NanoLeafRhythmTests
    {
        private readonly HttpResponseMessage _responseMessage;
        private readonly NanoLeafRhythm _nanoLeafRhythm;

        public NanoLeafRhythmTests()
        {
            _responseMessage = new HttpResponseMessage();
            var httpClient = HttpClientHelper.GetClientWithCustomResponse(_responseMessage);

            var apiContext = new NanoLeafApiContext("token", httpClient);

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
        }
    }
}