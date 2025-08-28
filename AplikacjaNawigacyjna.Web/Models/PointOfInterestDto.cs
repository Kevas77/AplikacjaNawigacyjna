using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AplikacjaNawigacyjna.Web.Models
{
    public class PointOfInterestDto
    {
        public string Xid { get; set; }

        public string Name { get; set; }

        public string Kinds { get; set; }
        public Point Point { get; set; }
    }
}
