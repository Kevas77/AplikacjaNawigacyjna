using AplikacjaNawigacyjna.Web.Models;
using AplikacjaNawigacyjna.Web.Services.IServices;
using AplikacjaNawigacyjna.Web.Utility;

namespace AplikacjaNawigacyjna.Web.Services
{
    public class POIService : IPOIService
    {
        private readonly IBaseService _baseService;
        public POIService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> GetAllPOI(BboxDto cords)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cords,
                Url = SD.POIAPIBase + "/api/poi"
            });
        }
    }
}
