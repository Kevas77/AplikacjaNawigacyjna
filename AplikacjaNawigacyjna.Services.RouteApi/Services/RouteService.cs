using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;
using AplikacjaNawigacyjna.Services.RouteApi.Models;
using AplikacjaNawigacyjna.Services.RouteApi.Models.DTOs;
using AplikacjaNawigacyjna.Services.RouteApi.Services.IServices;

namespace AplikacjaNawigacyjna.Services.RouteApi.Services
{
    public class RouteService : IRouteService
    {
        private readonly HttpClient _httpClient;
        private const string OsrmBaseUrl = "http://router.project-osrm.org";

        public RouteService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<RouteResponseDto> Calculate(RouteRequestDto request)
        {
            // Przygotuj współrzędne w formacie "lon,lat;lon,lat"
            var origin = $"{request.Origin.Longitude.ToString(System.Globalization.CultureInfo.InvariantCulture)},{request.Origin.Latitude.ToString(System.Globalization.CultureInfo.InvariantCulture)}";
            var destination = $"{request.Destination.Longitude.ToString(System.Globalization.CultureInfo.InvariantCulture)},{request.Destination.Latitude.ToString(System.Globalization.CultureInfo.InvariantCulture)}";
            var coordinates = $"{origin};{destination}";

            // Buduj URL do OSRM
            var url = $"{OsrmBaseUrl}/route/v1/driving/{coordinates}?overview=full&geometries=geojson";

            // Wyślij zapytanie
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);

            // Parsuj odpowiedź
            var route = doc.RootElement.GetProperty("routes")[0];
            var distance = route.GetProperty("distance").GetDouble();

            var geometry = route.GetProperty("geometry").GetProperty("coordinates");
            var path = new List<Coordinates>();
            foreach (var coord in geometry.EnumerateArray())
            {
                var lon = coord[0].GetDouble();
                var lat = coord[1].GetDouble();
                path.Add(new Coordinates { Latitude = lat, Longitude = lon });
            }

            return new RouteResponseDto
            {
                Path = path,
                DistanceInMeters = distance
            };
        }
    }
}