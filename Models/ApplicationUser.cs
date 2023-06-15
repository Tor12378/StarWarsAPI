using Microsoft.AspNetCore.Identity;

namespace StarWarsAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Character> Characters { get; set; }
    }
}