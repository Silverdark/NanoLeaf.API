using NanoLeaf.API.Tests.TestHelpers;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NanoLeaf.API.Tests
{
    public class NanoLeafPanelLayoutTests
    {
        private readonly HttpResponseMessage _responseMessage;
        private readonly NanoLeafPanelLayout _nanoLeafPanelLayout;

        private string _apiMessage;

        public NanoLeafPanelLayoutTests()
        {
            _responseMessage = new HttpResponseMessage();
            var httpClient = HttpClientHelper.GetClientWithCustomResponse(_responseMessage);

            Action<HttpRequestMessage, CancellationToken> callback
                = async (message, token) => _apiMessage = await message.Content.ReadAsStringAsync();
            HttpClientHelper.SetSendAsyncCallback(httpClient, callback);

            var apiContext = new NanoLeafApiContext("token", httpClient);
            _nanoLeafPanelLayout = new NanoLeafPanelLayout(apiContext);
        }

        [Fact]
        public async Task GetGlobalPanelOrientationAsync_Default_ReturnsValue()
        {
            // Arrange
            _responseMessage.Content = new StringContent("{'value': 5, 'max': 360, 'min': 0}");

            // Act
            var panelOrientation = await _nanoLeafPanelLayout.GetGlobalPanelOrientationAsync();

            // Assert
            Assert.Equal(5, panelOrientation.CurrentValue);
            Assert.Equal(360, panelOrientation.MaxValue);
            Assert.Equal(0, panelOrientation.MinValue);
        }

        [Fact]
        public async Task SetGlobalPanelOrientationAsync_SetGlobalOrientation_CorrectApiMessage()
        {
            // Act
            await _nanoLeafPanelLayout.SetGlobalPanelOrientationAsync(45);

            // Assert
            Assert.Equal("{'globalOrientation': {'value': 45}}", _apiMessage);
        }

        [Fact]
        public async Task GetPanelLayoutAsync_Default_ReturnsValue()
        {
            // Arrange
            _responseMessage.Content = new StringContent("{'numPanels': 3, 'sideLength': 150, " +
                "'positionData': [{'panelId': 186, 'x': -74, 'y': 43, 'o': 180}, {'panelId': 55, 'x': -74, 'y': 129, 'o': 0}]}");

            // Act
            var panelLayout = await _nanoLeafPanelLayout.GetPanelLayoutAsync();

            // Assert
            Assert.Equal(3, panelLayout.NumberOfPanels);
            Assert.Equal(150, panelLayout.SideLength);
            Assert.Equal(2, panelLayout.PanelPositions.Length);

            Assert.Equal(186, panelLayout.PanelPositions[0].PanelId);
            Assert.Equal(-74, panelLayout.PanelPositions[0].X);
            Assert.Equal(43, panelLayout.PanelPositions[0].Y);
            Assert.Equal(180, panelLayout.PanelPositions[0].Orientation);

            Assert.Equal(55, panelLayout.PanelPositions[1].PanelId);
            Assert.Equal(-74, panelLayout.PanelPositions[1].X);
            Assert.Equal(129, panelLayout.PanelPositions[1].Y);
            Assert.Equal(0, panelLayout.PanelPositions[1].Orientation);
        }
    }
}