using EniroClient.Api.Clients;

namespace EniroClient.Api
{
    public static class ClientFactory
    {
        public static IBasicCompanySearchClient BasicCompanySearchClient(string profile, string apiKey, string country)
        {
            return new BasicCompanySearchClient(profile, apiKey, "1.1.3", country);
        }

        public static IBasicCompanySearchClient BasicCompanySearchClientNo(string profile, string apiKey)
        {
            return new BasicCompanySearchClient(profile, apiKey, "1.1.3", "no");
        }

        public static IBasicCompanySearchClient BasicCompanySearchClientSe(string profile, string apiKey)
        {
            return new BasicCompanySearchClient(profile, apiKey, "1.1.3", "se");
        }

        public static IBasicCompanySearchClient BasicCompanySearchClientDk(string profile, string apiKey)
        {
            return new BasicCompanySearchClient(profile, apiKey, "1.1.3", "dk");
        }
    }
}
