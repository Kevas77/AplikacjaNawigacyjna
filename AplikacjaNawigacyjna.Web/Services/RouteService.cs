using AplikacjaNawigacyjna.Web.Models;
using AplikacjaNawigacyjna.Web.Services.IServices;
using AplikacjaNawigacyjna.Web.Utility;

namespace AplikacjaNawigacyjna.Web.Services
{
    public class RouteService : IRouteService
    {

        private readonly IBaseService _baseService;
        public RouteService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> Calculate(RouteRequestDto request)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = request,
                Url = SD.RouteAPIBase + "/api/route"
            });
        }
    }
}
