using System.Net;
using System.Text;

namespace EniroClient.Api.Utils
{
    public class QueryParameterBuilder : IQueryParameterBuilder
    {
        private readonly StringBuilder builder;
        private bool hasFirstParameter;

        public QueryParameterBuilder()
        {
            builder = new StringBuilder();
            hasFirstParameter = false;
        }

        public string Build()
        {
            return builder.ToString();
        }

        public void Add(string key, string value)
        {
            builder.Append(hasFirstParameter ? "&" : "?");
            hasFirstParameter = true;

            var v = WebUtility.UrlEncode(value);
            builder.Append(key + "=" + v);
        }

        public void Clear()
        {
            builder.Clear();
        }
    }
}
