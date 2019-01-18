using NanoLeaf.API.Tests.TestHelpers;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace NanoLeaf.API.Tests
{
    public class NanoLeafFactoryTests
    {
        private readonly HttpResponseMessage _responseMessage;
        private readonly NanoLeafFactory _nanoLeafFactory;

        public NanoLeafFactoryTests()
        {
            _responseMessage = new HttpResponseMessage();
            var httpClient = HttpClientHelper.GetClientWithCustomResponse(_responseMessage);

            _nanoLeafFactory = new NanoLeafFactory(httpClient);
        }

        [Fact]
        public async Task CreateNanoLeafAsync_WithConnectedNanoLeaf_ReturnsNanoLeafWithToken()
        {
            // Arrange
            const string authToken = "zbp3aHIDoj0Ox2iAr857WMFck58mOBaL";

            _responseMessage.StatusCode = HttpStatusCode.OK;
            _responseMessage.Content = new StringContent("{'auth_token': '" + authToken + "'}");

            // Act
            var nanoLeaf = await _nanoLeafFactory.CreateNanoLeafAsync();

            // Assert
            Assert.Equal(authToken, nanoLeaf.AuthorizationToken);
        }
    }
}