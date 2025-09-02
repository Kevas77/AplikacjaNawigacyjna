namespace AplikacjaNawigacyjna.Web.Utility
{
    public class SD
    {
        public static string MapPointAPIBase { get; set; }
        public static string RouteAPIBase { get; set; }
        public static string TrafficAPIBase { get; set; }
        public static string POIAPIBase { get; set; }
        public static string RouteHistoryAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
