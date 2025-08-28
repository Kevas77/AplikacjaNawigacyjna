using AplikacjaNawigacyjna.Services.LocalizationAPI.Models;
using AplikacjaNawigacyjna.Services.LocalizationAPI.Models.DTOs;

namespace AplikacjaNawigacyjna.Services.LocalizationAPI.Services.IServices
{
    public interface ILocationService
    {
        Task AddLocationAsync(LocationDto dto);
        Task<LocationDto?> GetCurrentLocationAsync(string userId);
    }
}
