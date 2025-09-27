using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Villa.Model.Entity
{
    public class VillaNumber
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillaNo { get; set; }
        public  string SpicialDetalis { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    
     

        [ForeignKey("Villa")]
        public int? VillaID { get; set; }

        public villa Villa { get; set; }

    }
}
