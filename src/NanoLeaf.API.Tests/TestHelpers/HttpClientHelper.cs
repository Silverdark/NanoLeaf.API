using Moq;
using Moq.Protected;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NanoLeaf.API.Tests.TestHelpers
{
    public static class HttpClientHelper
    {
        public static HttpClient GetClientWithCustomResponse(HttpResponseMessage responseMessage)
        {
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(responseMessage)
            ;

            var httpClientMock = new Mock<HttpClient>(httpMessageHandlerMock.Object);

            var httpClient = httpClientMock.Object;
            httpClient.BaseAddress = new Uri("http://localhost/");

            return httpClient;
        }

        public static void SetSendAsyncCallback(HttpClient client, Action<HttpRequestMessage, CancellationToken> action)
        {
            var httpClientMock = Mock.Get(client);

            httpClientMock
                .Setup(m => m.SendAsync(It.IsAny<HttpRequestMessage>(), It.IsAny<CancellationToken>()))
                .CallBase()
                .Callback(action)
            ;
        }
    }
}