using Microsoft.AspNetCore.Identity;

namespace ams.infrastructure.Data;
public class User : IdentityUser
{
    public string? Name { get; set; }
}
