using NanoLeaf.API.Tests.TestHelpers;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace NanoLeaf.API.Tests
{
    public class NanoLeafTests
    {
        private readonly HttpResponseMessage _responseMessage;
        private readonly NanoLeaf _nanoLeaf;

        public NanoLeafTests()
        {
            _responseMessage = new HttpResponseMessage();
            var httpClient = HttpClientHelper.GetClientWithCustomResponse(_responseMessage);

            var apiContext = new NanoLeafApiContext("token", httpClient);
            _nanoLeaf = new NanoLeaf(apiContext);
        }

        [Fact]
        public async Task GetDeviceInformationAsync_Default_ReturnsDeviceInformation()
        {
            // Arrange
            _responseMessage.Content = new StringContent("{'name': 'Nanoleaf Light Panels 52:c4:ce','serialNo': 'S18122A0754','manufacturer': 'Nanoleaf','firmwareVersion': '2.3.0','model': 'NL22','state': {'on': {'value': true},'brightness': {'value': 100,'max': 100,'min': 0},'hue': {'value': 0,'max': 360,'min': 0},'sat': {'value': 0,'max': 100,'min': 0},'ct': {'value': 4000,'max': 6500,'min': 1200},'colorMode': 'effect'},'effects': {'select': 'Northern Lights','effectsList': ['Color Burst','Flames','Forest','Inner Peace','Nemo','Northern Lights','Romantic','Snowfall']},'panelLayout': {'layout': {'numPanels': 1,'sideLength': 150,'positionData': [{'panelId': 186,'x': -74,'y': 43,'o': 180}]},'globalOrientation': {'value': 0,'max': 360,'min': 0}},'rhythm': {'rhythmConnected': false,'rhythmActive': null,'rhythmId': null,'hardwareVersion': null,'firmwareVersion': null,'auxAvailable': null,'rhythmMode': null,'rhythmPos': null}}");

            // Act
            var deviceInformation = await _nanoLeaf.GetDeviceInformationAsync();

            // Assert
            Assert.Equal("Nanoleaf Light Panels 52:c4:ce", deviceInformation.Name);
            Assert.Equal("S18122A0754", deviceInformation.SerialNumber);
            Assert.Equal("Nanoleaf", deviceInformation.Manufacturer);
            Assert.Equal("2.3.0", deviceInformation.FirmwareVersion);
            Assert.Equal("NL22", deviceInformation.Model);

            Assert.True(deviceInformation.State.IsPoweredOn);
            Assert.Equal(100, deviceInformation.State.Brightness.CurrentValue);
            Assert.Equal(100, deviceInformation.State.Brightness.MaxValue);
            Assert.Equal(0, deviceInformation.State.Brightness.MinValue);
            Assert.Equal(0, deviceInformation.State.Hue.CurrentValue);
            Assert.Equal(360, deviceInformation.State.Hue.MaxValue);
            Assert.Equal(0, deviceInformation.State.Hue.MinValue);
            Assert.Equal(0, deviceInformation.State.Saturation.CurrentValue);
            Assert.Equal(100, deviceInformation.State.Saturation.MaxValue);
            Assert.Equal(0, deviceInformation.State.Saturation.MinValue);
            Assert.Equal(4000, deviceInformation.State.ColorTemperature.CurrentValue);
            Assert.Equal(6500, deviceInformation.State.ColorTemperature.MaxValue);
            Assert.Equal(1200, deviceInformation.State.ColorTemperature.MinValue);
            Assert.Equal("effect", deviceInformation.State.ColorMode);

            Assert.Equal("Northern Lights", deviceInformation.Effects.CurrentEffect);
            Assert.Equal(8, deviceInformation.Effects.EffectsList.Length);

            Assert.Equal(1, deviceInformation.PanelLayout.Layout.NumberOfPanels);
            Assert.Equal(150, deviceInformation.PanelLayout.Layout.SideLength);
            Assert.Equal(186, deviceInformation.PanelLayout.Layout.PanelPositions[0].PanelId);
            Assert.Equal(-74, deviceInformation.PanelLayout.Layout.PanelPositions[0].X);
            Assert.Equal(43, deviceInformation.PanelLayout.Layout.PanelPositions[0].Y);
            Assert.Equal(180, deviceInformation.PanelLayout.Layout.PanelPositions[0].Orientation);
            Assert.Equal(0, deviceInformation.PanelLayout.GlobalOrientation.CurrentValue);
            Assert.Equal(360, deviceInformation.PanelLayout.GlobalOrientation.MaxValue);
            Assert.Equal(0, deviceInformation.PanelLayout.GlobalOrientation.MinValue);

            Assert.False(deviceInformation.Rhythm.IsConnected);
            Assert.Null(deviceInformation.Rhythm.IsActive);
            Assert.Null(deviceInformation.Rhythm.Id);
            Assert.Null(deviceInformation.Rhythm.HardwareVersion);
            Assert.Null(deviceInformation.Rhythm.FirmwareVersion);
            Assert.Null(deviceInformation.Rhythm.IsAuxCableAvailable);
            Assert.Null(deviceInformation.Rhythm.RhythmMode);
            Assert.Null(deviceInformation.Rhythm.Position);
        }
    }
}