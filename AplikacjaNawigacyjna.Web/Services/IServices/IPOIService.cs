using AplikacjaNawigacyjna.Web.Models;

namespace AplikacjaNawigacyjna.Web.Services.IServices
{
    public interface IPOIService
    {
        Task<ResponseDto?> GetAllPOI(BboxDto cords);
    }
}
