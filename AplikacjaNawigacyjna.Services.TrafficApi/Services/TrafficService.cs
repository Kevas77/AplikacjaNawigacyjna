using AplikacjaNawigacyjna.Services.TrafficApi.Models;
using AplikacjaNawigacyjna.Services.TrafficApi.Models.DTOs;
using AplikacjaNawigacyjna.Services.TrafficApi.Services.IServices;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text.Json;

namespace AplikacjaNawigacyjna.Services.TrafficApi.Services
{
    public class TrafficService : ITrafficService
    {
        private readonly HttpClient _httpClient;
        private readonly string _tomTomApiKey;

        public TrafficService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _tomTomApiKey = configuration["TomTomApi:ApiKey"];
        }
        public async Task<IEnumerable<TrafficEventDto>> GetAllEventsAsync(BboxDto cords)
        {
            var bbox = $"{cords.MinLon.ToString(System.Globalization.CultureInfo.InvariantCulture)},{cords.MinLat.ToString(System.Globalization.CultureInfo.InvariantCulture)},{cords.MaxLon.ToString(System.Globalization.CultureInfo.InvariantCulture)},{cords.MaxLat.ToString(System.Globalization.CultureInfo.InvariantCulture)}"; // "20.0,52.0,21.0,52.5";
            var url = $"https://api.tomtom.com/traffic/services/5/incidentDetails?bbox={bbox}&key={_tomTomApiKey}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return Enumerable.Empty<TrafficEventDto>();

            using var stream = await response.Content.ReadAsStreamAsync();
            using var doc = await JsonDocument.ParseAsync(stream);

            var events = new List<TrafficEventDto>();

            var root = doc.RootElement;
            if (root.TryGetProperty("incidents", out var incidents))
            {
                foreach (var incident in incidents.EnumerateArray())
                {
                    var type = incident.GetProperty("type").GetString() ?? string.Empty;

                    Coordinates coords = new Coordinates();
                    if (incident.TryGetProperty("geometry", out var geometry) &&
                        geometry.TryGetProperty("coordinates", out var coordinatesElem) &&
                        coordinatesElem.ValueKind == JsonValueKind.Array &&
                        coordinatesElem.GetArrayLength() > 0)
                    {
                        var coordArray = coordinatesElem[0];
                        if (coordArray.ValueKind == JsonValueKind.Array &&
                            coordArray.GetArrayLength() == 2)
                        {
                            coords.Longitude = coordArray[0].GetDouble();
                            coords.Latitude = coordArray[1].GetDouble();
                        }
                    }

                    events.Add(new TrafficEventDto
                    {
                        Location = coords,
                        Type = type
                    });
                }
            }

            return events;
        }
    }
}
