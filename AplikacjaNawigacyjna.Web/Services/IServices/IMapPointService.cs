using AplikacjaNawigacyjna.Web.Models;

namespace AplikacjaNawigacyjna.Web.Services.IServices
{
    public interface IMapPointService
    {
        Task<ResponseDto?> GetAllMapPointsAsync();
        Task<ResponseDto?> GetMapPointByCode(string code);
        Task<ResponseDto?> CreateMapPointAsync(MapPointDto mapPointDto);
        Task<ResponseDto?> UpdateMapPointAsync(MapPointDto mapPointDto);
        Task<ResponseDto?> DeleteMapPointAsync(string name);
    }
}
