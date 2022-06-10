using Microsoft.AspNetCore.Identity;
namespace PlaneEncyclopedia.Models
{
    public class User: IdentityUser
    {
        public ICollection<Plane> Planes { get; set; }
        public ICollection<Missile> Missiles { get; set; }
    }
}
