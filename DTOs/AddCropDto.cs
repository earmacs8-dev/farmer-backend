using System.ComponentModel.DataAnnotations;

namespace FarmerApp.Api.DTOs
{
    public class AddCropDto
    {
        [Required]
        public DateTime StartDate { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal AreaOfPlanting { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal SeedRate { get; set; }

        [Required]
        public string SeedType { get; set; } = string.Empty;

        [Required]
        public string SoilType { get; set; } = string.Empty;

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }
    }
}
