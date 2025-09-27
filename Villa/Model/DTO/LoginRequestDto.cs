using System.ComponentModel.DataAnnotations;

namespace Villa.Model.DTO
{
    public class LoginRequestDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
     
    }
}
