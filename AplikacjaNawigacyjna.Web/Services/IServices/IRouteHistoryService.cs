using AplikacjaNawigacyjna.Web.Models;

namespace AplikacjaNawigacyjna.Web.Services.IServices
{
    public interface IRouteHistoryService
    {
        Task<ResponseDto?> GetRoutesHistoryAsync();
        Task<ResponseDto?> CreateRouteRecordAsync(RouteRecordDto routeRecordDto);
        Task<ResponseDto?> DeleteRouteRecordAsync(string code);
    }
}

