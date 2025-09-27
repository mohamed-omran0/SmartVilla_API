using System.ComponentModel.DataAnnotations;

namespace Villa.Model.DTO
{
    public class AddVillaDto
    {
      
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public string Details { get; set; }
        public double Rate { get; set; }
        public int Sqft { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }
    }
}
