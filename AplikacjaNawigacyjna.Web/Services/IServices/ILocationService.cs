using AplikacjaNawigacyjna.Web.Models;

namespace AplikacjaNawigacyjna.Web.Services.IServices
{
    public interface ILocationService
    {
        Task<ResponseDto?> AddLocationAsync(LocationDto dto);
        Task<ResponseDto?> GetCurrentLocationAsync(string userId);
    }
}
