using AplikacjaNawigacyjna.Web.Models;
using AplikacjaNawigacyjna.Web.Services.IServices;
using AplikacjaNawigacyjna.Web.Utility;
using Azure.Core;

namespace AplikacjaNawigacyjna.Web.Services
{
    public class TrafficService : ITrafficService
    {
        private readonly IBaseService _baseService;
        public TrafficService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> GetAllEventsAsync(BboxDto cords)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cords,
                Url = SD.TrafficAPIBase + "/api/traffic"
            });
        }
    }
}
