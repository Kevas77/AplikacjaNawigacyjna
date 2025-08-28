namespace AplikacjaNawigacyjna.Web.Models
{
    public class RouteResponseDto
    {
        public List<Coordinates> Path { get; set; }
        public double DistanceInMeters { get; set; }
    }
}
