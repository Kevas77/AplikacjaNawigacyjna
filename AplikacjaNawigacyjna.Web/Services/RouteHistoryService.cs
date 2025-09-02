using AplikacjaNawigacyjna.Web.Models;
using AplikacjaNawigacyjna.Web.Services.IServices;
using AplikacjaNawigacyjna.Web.Utility;

namespace AplikacjaNawigacyjna.Web.Services
{
    public class RouteHistoryService : IRouteHistoryService
    {
        private readonly IBaseService _baseService;
        public RouteHistoryService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateRouteRecordAsync(RouteRecordDto routeRecordDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = routeRecordDto,
                Url = SD.RouteHistoryAPIBase + "/api/routehistory"
            });
        }

        public async Task<ResponseDto?> DeleteRouteRecordAsync(string code)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.RouteHistoryAPIBase + $"/api/routehistory/{code}"
            });
        }

        public async Task<ResponseDto?> GetRoutesHistoryAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.RouteHistoryAPIBase + "/api/routehistory"
            });
        }
    }
}
