using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Villa.Model.Entity
{
    public class villa
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Details { get; set; }
        public double Rate { get; set; }
        public int Sqft { get; set; } // مساحة الفيلا بالقدم المربع
        public string ImageUrl { get; set; }
        public string Amenity { get; set; } //وسائل الراحه 
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }

        public ICollection<VillaNumber> villaNumbers { get; set; }
    }
}
