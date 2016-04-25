using System;
using System.Net.Http;
using System.Threading.Tasks;
using EniroClient.Api.Utils;

namespace EniroClient.Api
{
    public abstract class ClientBase
    {
        private const int DefaultTimeOutInSeconds = 5;
        private const string BaseUrl = "http://api.eniro.com";
        private readonly string path;
        private readonly IQueryParameterBuilder builder;

        protected string ProfileName;
        protected string ApiKey;
        protected string Version;
        protected string Country;

        public TimeSpan TimeOut { get; set; }
        
        protected ClientBase(string url, string profileName, string apiKey, string version, string country)
            : this(url, DefaultTimeOutInSeconds, profileName, apiKey, version, country)
        {
        }

        protected ClientBase(string url, int timeoutInSeconds, string profileName, string apiKey, string version, string country)
        {
            TimeOut = TimeSpan.FromSeconds(timeoutInSeconds);
            ProfileName = profileName;
            ApiKey = apiKey;
            Version = version;
            Country = country;
            path = url;
            builder = new QueryParameterBuilder();
        }

        protected ClientBase(IQueryParameterBuilder b, string url, int timeoutInSeconds, string profileName, string apiKey, string version, string country)
        {
            TimeOut = TimeSpan.FromSeconds(timeoutInSeconds);
            ProfileName = profileName;
            ApiKey = apiKey;
            Version = version;
            Country = country;
            path = url;
            builder = b;
        }

        protected async Task<ApiResult<T>> GetAsync<T>()
            where T : class
        {
            AddQueryParameter("profile", ProfileName);
            AddQueryParameter("key", ApiKey);
            AddQueryParameter("country", Country);
            AddQueryParameter("version", Version);
            using (var c = new HttpClient())
            {
                c.Timeout = TimeOut;
                var result = await c.GetAsync(BaseUrl + path + builder.Build());
                var content = await result.Content.ReadAsStringAsync();
                var o = JsonSerializer.Deserialize<T>(content);
                return new ApiResult<T>
                {
                    Content = o,
                    Message = result.ReasonPhrase,
                    StatusCode = (int) result.StatusCode
                };
            }
        }

        protected ApiResult<T> Get<T>(string queryString)
            where T : class
        {
            return GetAsync<T>().Result;
        }

        protected void AddQueryParameter(string key, string value)
        {
            builder.Add(key, value);
        }

        protected void ClearQueryParameters()
        {
            builder.Clear();
        }
    }
}
