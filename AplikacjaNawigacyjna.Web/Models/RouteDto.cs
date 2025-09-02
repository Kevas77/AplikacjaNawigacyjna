namespace AplikacjaNawigacyjna.Web.Models
{
    public class RouteDto
    {
        public Coordinates Origin { get; set; }
        public Coordinates Destination { get; set; }
        public string? StartName { get; set; }
        public string? EndName { get; set; }
    }
}
