using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace apsys.imbera.identityserverclient.webapi
{
    public static class IPrincipalExtender
    {

        /// <summary>
        /// Get a claim from iprincipal 
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="claimType"></param>
        /// <returns></returns>
        public static Claim GetClaim(this IPrincipal principal, string claimType)
        {
            ClaimsPrincipal claims = principal as ClaimsPrincipal;
            return claims.FindFirst(claimType);
        }

        /// <summary>
        /// Get a claim value
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="claimType"></param>
        /// <returns></returns>
        public static string GetClaimValue(this IPrincipal principal, string claimType)
        {
            var claimn = GetClaim(principal, claimType);
            return claimn == null ? string.Empty : claimn.Value;
        }

        /// <summary>
        /// Get the username from the iprincipal claims
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static string GetUserName(this IPrincipal principal) => GetClaimValue(principal, "username");
    }
}