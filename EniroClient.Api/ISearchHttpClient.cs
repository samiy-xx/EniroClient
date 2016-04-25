using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EniroClient.Api
{
    public interface ISearchHttpClient
    {
        TimeSpan TimeOut { get; set; }
        Task<HttpResponseMessage> DeleteAsync(string requestUri);
        Task<HttpResponseMessage> GetAsync(Uri requestUri);
        Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content);
        Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content);
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
        void Dispose();
    }
}