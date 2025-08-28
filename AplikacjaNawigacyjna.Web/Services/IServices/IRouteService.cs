using AplikacjaNawigacyjna.Web.Models;

namespace AplikacjaNawigacyjna.Web.Services.IServices
{
    public interface IRouteService
    {
        Task<ResponseDto?> Calculate(RouteRequestDto request);
    }
}
