using System;
using System.Net.Http;

namespace NanoLeaf.API
{
    internal class NanoLeafApiContext
    {
        internal NanoLeafApiContext(string authToken, HttpClient httpClient)
        {
            AuthToken = authToken;
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public string AuthToken { get; }
        public HttpClient HttpClient { get; }
    }
}