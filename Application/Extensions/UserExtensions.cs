using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class UserExtensions
    {
        public static int GetUserId(this ClaimsPrincipal claims)
        {
            if (claims != null)
            {
                var data = claims.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

                if (data != null)
                    return Convert.ToInt32(data.Value);
            }
            return default(int);
        }

        public static int GetUserId(this IPrincipal principal)
        {
            var user = (ClaimsPrincipal)principal;

            return user.GetUserId();
        }
    }
}
