using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Models
{
    public class PointOfIntresetforCreationDto
    {
        [Required(ErrorMessage = "Name Value Is Required")]
        [MaxLength(50)]
        public string Name { get; set; } = String.Empty;

        [MaxLength(100)]
        public string? Description { get; set; }
    }
}
