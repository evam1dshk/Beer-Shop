using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;

namespace MyBeerShop.Infrastructure
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool IsAdmin(this ClaimsPrincipal user)
            => user.IsInRole("Admin");
    }
}
