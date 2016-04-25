using System.Threading.Tasks;
using EniroClient.Common.Dto;

namespace EniroClient.Api.Clients
{
    public class BasicCompanySearchClient : ClientBase
    {
       
        public BasicCompanySearchClient(string profile, string apiKey, string version, string country) 
            : this("/cs/search/basic", profile, apiKey, version, country)
        {
        }

        public BasicCompanySearchClient(string url, string profile, string apiKey, string version, string country)
            : base(url, profile, apiKey, version, country)
        {
            
        }

        public BasicCompanySearchClient(string url, int timeoutInSeconds, string profile, string apiKey, string version, string country) 
            : base(url, timeoutInSeconds, profile, apiKey, version, country)
        {
           
        }

        public async Task<ApiResult<EniroResult>> SearchById(string eniroId)
        {
            ClearQueryParameters();
            AddQueryParameter("eniro_id", eniroId);
            return await GetAsync<EniroResult>();
        }

        public async Task<ApiResult<EniroResult>> Search(string query, string area = null, int start = -1, int end = -1)
        {
            ClearQueryParameters();
            AddQueryParameter("search_word", query);
            if (!string.IsNullOrWhiteSpace(area))
                AddQueryParameter("geo_area", area);
            if (start >= 0)
                AddQueryParameter("from_list", start.ToString());
            if (end >= 0)
                AddQueryParameter("to_list", end.ToString());
            return await GetAsync<EniroResult>();
        }

        public async Task<ApiResult<EniroResult>> SearchCoordinates(double latitude, double longitude, int maxDistance = -1, int start = -1, int end = -1)
        {
            ClearQueryParameters();
            AddQueryParameter("latitude", latitude.ToString());
            AddQueryParameter("longitude", longitude.ToString());
            if (maxDistance > -1)
                AddQueryParameter("max_distance", maxDistance.ToString());
            if (start >= 0)
                AddQueryParameter("from_list", start.ToString());
            if (end >= 0)
                AddQueryParameter("to_list", end.ToString());
            return await GetAsync<EniroResult>();
        }

        public async Task<ApiResult<EniroResult>> SearchCoordinates(string query, double latitude, double longitude, int maxDistance = -1, int start = -1, int end = -1)
        {
            ClearQueryParameters();
            if (!string.IsNullOrWhiteSpace(query))
                AddQueryParameter("search_word", query);
            AddQueryParameter("latitude", latitude.ToString());
            AddQueryParameter("longitude", longitude.ToString());
            if (maxDistance > -1)
                AddQueryParameter("max_distance", maxDistance.ToString());
            if (start >= 0)
                AddQueryParameter("from_list", start.ToString());
            if (end >= 0)
                AddQueryParameter("to_list", end.ToString());
            return await GetAsync<EniroResult>();
        }
    }
}
