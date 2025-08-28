using AplikacjaNawigacyjna.Web.Models;

namespace AplikacjaNawigacyjna.Web.Services.IServices
{
    public interface ITrafficService
    {
        Task<ResponseDto?> GetAllEventsAsync(BboxDto cords);
    }
}
