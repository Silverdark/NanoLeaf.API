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
        /// <summary>
        /// Creates a mocked <see cref="HttpClient"/> with a custom
        /// <see cref="HttpClient.SendAsync(HttpRequestMessage, CancellationToken)"/> implementation
        /// (returns the <paramref name="responseMessage"/>)
        /// </summary>
        /// <param name="responseMessage">The response message which will be returned from SendAsync.</param>
        /// <param name="action">Action which is performed when a request is send to the API.</param>
        /// <returns>A mocked HttpClient</returns>
        public static HttpClient GetMockedClient(HttpResponseMessage responseMessage,
                                                 Action<HttpRequestMessage> action = null)
        {
            // Set an empty action if there's no action
            if (action == null)
                action = message => { };

            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(responseMessage)
                .Callback((HttpRequestMessage request, CancellationToken cancellationToken) => action(request))
                ;

            var httpClientMock = new Mock<HttpClient>(httpMessageHandlerMock.Object) { CallBase = true };

            httpClientMock
                .Setup(m => m.SendAsync(It.IsAny<HttpRequestMessage>(), It.IsAny<CancellationToken>()))
                .CallBase()
                .Callback((HttpRequestMessage request, CancellationToken cancellationToken) => action(request))
                ;

            var httpClient = httpClientMock.Object;
            httpClient.BaseAddress = new Uri("http://localhost/api/v1/");

            return httpClient;
        }
    }
}