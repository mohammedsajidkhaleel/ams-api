using ams.infrastructure.Data;
using System.Security.Claims;

namespace ams.api.Extensions;

public static class UserExtensions
{
    public static Guid GetLoggedInUser(this ClaimsPrincipal user)
    {
        Claim? obj = user.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier") ?? user.FindFirst("sub");
        if (obj == null)
        {
            throw new UnauthorizedAccessException("User sub id not found");
        }

        return new Guid(obj.Value);
    }
}
