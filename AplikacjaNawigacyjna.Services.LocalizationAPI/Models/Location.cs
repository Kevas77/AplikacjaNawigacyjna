using System.ComponentModel.DataAnnotations;

namespace AplikacjaNawigacyjna.Services.LocalizationAPI.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
