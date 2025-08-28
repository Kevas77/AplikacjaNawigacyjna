using AplikacjaNawigacyjna.Services.TrafficApi.Models.DTOs;

namespace AplikacjaNawigacyjna.Services.TrafficApi.Services.IServices
{
    public interface ITrafficService
    {
        Task<IEnumerable<TrafficEventDto>> GetAllEventsAsync(BboxDto cords);
    }
}
