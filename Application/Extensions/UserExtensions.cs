using System.Security.Claims;
using System.Security.Principal;

namespace Application.Extensions
{
    public static class UserExtensions
    {
        public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            var userId = claimsPrincipal.FindFirst("UserId")?.Value;

            if (!string.IsNullOrWhiteSpace(userId))
            {
                return int.Parse(userId);
            }
            else
            {
                return default(int);
            }
        }

    }
}
