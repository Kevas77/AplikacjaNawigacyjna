using AplikacjaNawigacyjna.Web.Models;
using AplikacjaNawigacyjna.Web.Services.IServices;
using AplikacjaNawigacyjna.Web.Utility;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AplikacjaNawigacyjna.Web.Services
{
    public class LocationService : ILocationService
    {
        private readonly IBaseService _baseService;

        public LocationService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> AddLocationAsync(LocationDto dto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = SD.LocationAPIBase + "/api/location"
            });
        }

        public async Task<ResponseDto?> GetCurrentLocationAsync(string userId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.LocationAPIBase + $"/api/location/current/{userId}"
            });
        }
    }
}
