using Villa.Model.Entity;

namespace Villa.Model.DTO
{
    public class LoginResponceDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
    }
}
