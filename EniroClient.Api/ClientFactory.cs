using EniroClient.Api.Clients;

namespace EniroClient.Api
{
    public static class ClientFactory
    {
        public static BasicCompanySearchClient BasicCompanySearchClient(string profile, string apiKey, string country)
        {
            return new BasicCompanySearchClient(profile, apiKey, "1.0.0", country);
        }

        public static BasicCompanySearchClient BasicCompanySearchClientNorway(string profile, string apiKey)
        {
            return new BasicCompanySearchClient(profile, apiKey, "1.0.0", "no");
        }

        public static BasicCompanySearchClient BasicCompanySearchClientSweden(string profile, string apiKey)
        {
            return new BasicCompanySearchClient(profile, apiKey, "1.0.0", "se");
        }

    }
}
