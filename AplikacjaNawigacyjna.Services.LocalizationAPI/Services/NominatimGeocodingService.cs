using AplikacjaNawigacyjna.Services.LocalizationAPI.Services.IServices;
using System.Net.Http;
using System.Text.Json;

namespace AplikacjaNawigacyjna.Services.LocalizationAPI.Services
{
    public class NominatimGeocodingService : IGeocodingService
    {
        private readonly HttpClient _httpClient;

        public NominatimGeocodingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAddressAsync(double latitude, double longitude)
        {
            var url = $"https://nominatim.openstreetmap.org/reverse?format=jsonv2&lat={latitude}&lon={longitude}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("User-Agent", "YourAppName");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            var address = doc.RootElement.GetProperty("display_name").GetString();

            return address ?? "Nieznany adres";
        }

    }
}
