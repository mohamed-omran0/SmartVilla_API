using Microsoft.AspNetCore.Identity;

namespace Villa.Model.Entity
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
    }
}
