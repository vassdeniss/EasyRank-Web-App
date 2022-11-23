using System;
using System.Security.Claims;

namespace EasyRank.Web.Claims
{
    /// <summary>
    /// The class for different claim extensions.
    /// </summary>
    public static class ClaimsExtensions
    {
        /// <summary>
        /// Adds an extension 'Id' for getting the Guid of the user.
        /// </summary>
        /// <param name="user">The current user.</param>
        /// <returns>The Guid of the user.</returns>
        public static Guid Id(this ClaimsPrincipal user)
        {
            return Guid.Parse(user.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        }
    }
}
