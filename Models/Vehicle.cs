using System.ComponentModel.DataAnnotations;

namespace VehicleApi.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Make { get; set; } = string.Empty;

        [Required]
        [StringLength(40)]
        public string Model { get; set; } = string.Empty;

        [Range(1886, 2100)]
        public int Year { get; set; }

        [StringLength(20)]
        public string? Color { get; set; }

        // VIN típicamente 17 caracteres (puede ajustarse)
        [StringLength(17, MinimumLength = 11)]
        public string? Vin { get; set; }
    }
}