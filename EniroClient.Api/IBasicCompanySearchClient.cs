using System.Threading.Tasks;
using EniroClient.Common.Dto;

namespace EniroClient.Api
{
    public interface IBasicCompanySearchClient
    {
        Task<ApiResult<EniroResult>> Search(string query, string area = null, int start = -1, int end = -1);
        Task<ApiResult<EniroResult>> SearchById(string eniroId);
        Task<ApiResult<EniroResult>> SearchCoordinates(double latitude, double longitude, int maxDistance = -1, int start = -1, int end = -1);
        Task<ApiResult<EniroResult>> SearchCoordinates(string query, double latitude, double longitude, int maxDistance = -1, int start = -1, int end = -1);
    }
}