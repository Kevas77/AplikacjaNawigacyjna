using static AplikacjaNawigacyjna.Web.Utility.SD;

namespace AplikacjaNawigacyjna.Web.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data {get; set; }
    }
}
