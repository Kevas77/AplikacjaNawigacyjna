namespace AplikacjaNawigacyjna.Services.RouteApi.Models.DTOs
{
    public class RouteResponseDto
    {
        public List<Coordinates> Path { get; set; }
        public double DistanceInMeters { get; set; }
    }
}
