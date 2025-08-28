namespace AplikacjaNawigacyjna.Services.LocalizationAPI.Services.IServices
{
    public interface IGeocodingService
    {
        Task<string> GetAddressAsync(double latitude, double longitude);
    }
}
