using AplikacjaNawigacyjna.Services.POIApi.Models.DTOs;

namespace AplikacjaNawigacyjna.Services.POIApi.Services.IServices
{
    public interface IPOIService
    {
        Task<IEnumerable<PointOfInterestDto>> GetAllPOI(BboxDto cords);
    }
}
