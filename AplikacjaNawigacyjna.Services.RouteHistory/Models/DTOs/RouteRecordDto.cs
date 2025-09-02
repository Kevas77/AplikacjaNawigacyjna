namespace AplikacjaNawigacyjna.Services.RouteHistory.Models.DTOs
{
    public class RouteRecordDto
    {
        public string Code { get; set; }
        public string StartName { get; set; }
        public string EndName { get; set; }
        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }
        public double EndLatitude { get; set; }
        public double EndLongitude { get; set; }
        public double Distance { get; set; }
    }
}
