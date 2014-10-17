using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using KSEPM.Web.Database.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KSEPM.Web.Database.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime? StartToWork { get; set; }
        public DateTime? StopToWork { get; set; }
        public bool? IsActive { get; set; }
        public string Description { get; set; }
        public string PointType { get; set; }
        public virtual ICollection<Sell> Sells { get; set; }
        public virtual ICollection<UserCallback> UserCallbacks { get; set; } 

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim("FirstName", FirstName));
            // Add custom user claims here
            return userIdentity;
        }
    }
}
