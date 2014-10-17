using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KSEPM.Web.App_Start;
using KSEPM.Web.Database.Identity;
using KSEPM.Web.Infrastructure.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace KSEPM.Web.Controllers.BaseControllers
{
    public class ManagerBaseController : BaseController
    {
        protected ApplicationUserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
        }

        protected ApplicationSignInManager SignInManager
        {
            get { return HttpContext.GetOwinContext().Get<ApplicationSignInManager>(); }
        }

        protected IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        protected ApplicationRoleManager RoleManager
        {
            get { return HttpContext.GetOwinContext().Get<ApplicationRoleManager>(); }
        }

        protected void AddErrors(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        protected IEnumerable<ApplicationUser> GetUsersByRole(string role)
        {
            var users = RoleManager.FindByName(role).Users.Select(x => x.UserId).ToList();
            var appUsers = UserManager.Users.Where(x => users.Contains(x.Id));

            return appUsers;
        }

        protected ApplicationUser GetCurrentUser()
        {
            return UserManager.FindById(User.Identity.GetUserId());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (UserManager != null)
                {
                    UserManager.Dispose();
                }
                if (SignInManager != null)
                {
                    SignInManager.Dispose();
                }
                if (RoleManager != null)
                {
                    RoleManager.Dispose();
                }
            }
            base.Dispose(disposing);
        }

    }
}