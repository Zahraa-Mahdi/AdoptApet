using Microsoft.AspNetCore.Identity;

namespace AdoptApet.Models;
public class AppUser : IdentityUser
{

    public string Occupation { get; set; }
}
