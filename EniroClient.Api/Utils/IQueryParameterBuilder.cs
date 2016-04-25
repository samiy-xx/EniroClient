namespace EniroClient.Api.Utils
{
    public interface IQueryParameterBuilder
    {
        void Add(string key, string value);
        string Build();
        void Clear();
    }
}