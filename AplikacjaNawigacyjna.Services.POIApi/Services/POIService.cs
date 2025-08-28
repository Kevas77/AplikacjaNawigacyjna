using AplikacjaNawigacyjna.Services.POIApi.Models.DTOs;
using AplikacjaNawigacyjna.Services.POIApi.Services.IServices;
using System.Collections.Generic;
using System.Text.Json;

namespace AplikacjaNawigacyjna.Services.POIApi.Services
{
    public class POIService : IPOIService
    {
        private readonly HttpClient _httpClient;
        private readonly string _openTripMapApiKey;

        public POIService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _openTripMapApiKey = configuration["OpenTripMapApi:ApiKey"];
        }

        public async Task<IEnumerable<PointOfInterestDto>> GetAllPOI(BboxDto cords)
        {
            string lonMin = cords.MinLon.ToString(System.Globalization.CultureInfo.InvariantCulture);
            string latMin = cords.MinLat.ToString(System.Globalization.CultureInfo.InvariantCulture);
            string lonMax = cords.MaxLon.ToString(System.Globalization.CultureInfo.InvariantCulture);
            string latMax = cords.MaxLat.ToString(System.Globalization.CultureInfo.InvariantCulture);

            string url = $"https://api.opentripmap.com/0.1/en/places/bbox" +
                    $"?lon_min={lonMin}&lat_min={latMin}" +
                    $"&lon_max={lonMax}&lat_max={latMax}" +
                    $"&limit=10&format=json&apikey={_openTripMapApiKey}";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return Enumerable.Empty<PointOfInterestDto>();

            string json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<PointOfInterestDto> places = JsonSerializer.Deserialize<List<PointOfInterestDto>>(json, options);

            foreach (var p in places)
            {
                var singleKind = p.Kinds?
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .FirstOrDefault()
                    .Trim();
                p.Kinds = singleKind ?? "other";
            }

            return places ?? Enumerable.Empty<PointOfInterestDto>();
        }
    }
}
