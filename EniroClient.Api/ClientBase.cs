using System;
using System.Threading.Tasks;
using EniroClient.Api.Utils;

namespace EniroClient.Api
{
    public abstract class ClientBase : IDisposable
    {
        private const int DefaultTimeOutInSeconds = 5;
        private const string BaseUrl = "http://api.eniro.com";
        private readonly string path;
        private readonly IQueryParameterBuilder builder;
        private readonly ISearchHttpClient client;

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
            client = new SearchHttpClient();
        }

        protected ClientBase(ISearchHttpClient c, IQueryParameterBuilder b, string url, int timeoutInSeconds, string profileName, string apiKey, string version, string country)
        {
            TimeOut = TimeSpan.FromSeconds(timeoutInSeconds);
            ProfileName = profileName;
            ApiKey = apiKey;
            Version = version;
            Country = country;
            path = url;
            builder = b;
            client = c;
        }

        protected async Task<ApiResult<T>> GetAsync<T>()
            where T : class
        {
            AddQueryParameter("profile", ProfileName);
            AddQueryParameter("key", ApiKey);
            AddQueryParameter("country", Country);
            AddQueryParameter("version", Version);

            client.TimeOut = TimeOut;
            var result = await client.GetAsync(new Uri(BaseUrl + path + builder.Build()));
            var content = await result.Content.ReadAsStringAsync();
            var o = JsonSerializer.Deserialize<T>(content);
            return new ApiResult<T>
            {
                Content = o,
                Message = result.ReasonPhrase,
                StatusCode = (int) result.StatusCode
            };
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

        public virtual void Dispose()
        {
            client.Dispose();
        }
    }
}
