using Microsoft.AspNetCore.Identity;

namespace RestAPI.Models.Entity
{
    public class AppUser : IdentityUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
        
    }
}
