using AplikacjaNawigacyjna.Web.Models;
using AplikacjaNawigacyjna.Web.Services.IServices;
using AplikacjaNawigacyjna.Web.Utility;

namespace AplikacjaNawigacyjna.Web.Services
{
    public class MapPointService : IMapPointService
    {
        private readonly IBaseService _baseService;
        public MapPointService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> GetAllMapPointsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.MapPointAPIBase + "/api/mappoint"
            });
        }
        public async Task<ResponseDto?> GetMapPointByCode(string code)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.MapPointAPIBase + $"/api/mappoint/GetByCode/{code}"
            });
        }
        public async Task<ResponseDto?> CreateMapPointAsync(MapPointDto mapPointDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = mapPointDto,
                Url = SD.MapPointAPIBase + "/api/mappoint"
            });
        }
        public async Task<ResponseDto?> UpdateMapPointAsync(MapPointDto mapPointDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = mapPointDto,
                Url = SD.MapPointAPIBase + "/api/mappoint"
            });
        }
        public async Task<ResponseDto?> DeleteMapPointAsync(string code)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.MapPointAPIBase + $"/api/mappoint/{code}"
            });
        }
    }
}
