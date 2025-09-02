using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AplikacjaNawigacyjna.Services.RouteHistory.Models
{
    [Index(nameof(Code), IsUnique = true)]
    public class RouteRecord
    {
        [Key]
        public string Code { get; set; }
        [Required]
        public string StartName { get; set; }
        [Required]
        public string EndName { get; set; }
        [Required]
        public double StartLatitude { get; set; }
        [Required]
        public double StartLongitude { get; set; }
        [Required]
        public double EndLatitude { get; set; }
        [Required]
        public double EndLongitude { get; set; }
        [Required]
        public double Distance { get; set; }
    }
}
