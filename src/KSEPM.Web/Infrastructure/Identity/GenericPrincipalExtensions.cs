using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace KSEPM.Web.Infrastructure.Identity
{
    public static class GenericPrincipalExtensions
    {
        public static string FirstName(this IPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                var claimsIdentity = user.Identity as ClaimsIdentity;
                if (claimsIdentity == null)
                    return "";
                foreach (var claim in claimsIdentity.Claims)
                {
                    if (claim.Type == "FirstName")
                        return claim.Value;
                }
                return "";
            }
            return "";
        }
    }
}