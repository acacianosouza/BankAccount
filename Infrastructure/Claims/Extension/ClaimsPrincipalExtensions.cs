using System.Linq;
using System.Security.Claims;

namespace Infrastructure.Claims.Extension
{
    public static class ClaimsPrincipalExtensions
    {
        public static string UserName(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.Claims.FirstOrDefault(claim => claim.Type == "Name").Value;
        }

        public static string UserId(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.Claims.FirstOrDefault(claim => claim.Type == "IdUser").Value;
        }
    }
}
