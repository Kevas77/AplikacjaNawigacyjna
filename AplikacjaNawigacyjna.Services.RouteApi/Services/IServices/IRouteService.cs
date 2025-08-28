using AplikacjaNawigacyjna.Services.RouteApi.Models.DTOs;

namespace AplikacjaNawigacyjna.Services.RouteApi.Services.IServices
{
    public interface IRouteService
    {
        Task<RouteResponseDto> Calculate(RouteRequestDto request);
    }
}
