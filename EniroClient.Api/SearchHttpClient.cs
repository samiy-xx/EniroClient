using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EniroClient.Api
{
    public class SearchHttpClient : ISearchHttpClient, IDisposable
    {
        private readonly HttpClient client;

        public TimeSpan TimeOut
        {
            get { return client.Timeout; }
            set { client.Timeout = value; }
        }

        public SearchHttpClient()
        {
            client = new HttpClient();
        }

        public Task<HttpResponseMessage> DeleteAsync(string requestUri)
        {
            return client.DeleteAsync(requestUri);
        }

        public Task<HttpResponseMessage> GetAsync(Uri requestUri)
        {
            return client.GetAsync(requestUri);
        }

        public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
        {
            return client.PostAsync(requestUri, content);
        }

        public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content)
        {
            return client.PutAsync(requestUri, content);
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return client.SendAsync(request);
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
