using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using KSEPM.Resources.Errors;
using KSEPM.Web.Controllers.BaseControllers;
using KSEPM.Web.Database;
using KSEPM.Web.Database.Identity;
using KSEPM.Web.Infrastructure.Attributes;
using KSEPM.Web.Infrastructure.Identity;
using KSEPM.Web.Models.AccountViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
namespace KSEPM.Web.Controllers
{
    [CustomValidateAntiForgeryToken]
    [RoutePrefix("Account")]
    [AllowAnonymous]
    public class LoginController : ManagerBaseController
    {
        private IKSEPMRepository _repository;

        public LoginController(IKSEPMRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("Login")]
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ErrorMessage.ERR_loginform_emply_passorlogin);
                return View(model);
            }

            SignInStatus result =
                await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, true);
            switch (result)
            {
                case SignInStatus.Success:
                    return Redirect(GetRedirectUrl(model.ReturnUrl));
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", ErrorMessage.ERR_loginform_wrong_passorlogin);
                    return View(model);
            }
        }

        [Route("Logout")]
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Lockout()
        {
            return View();
        }

        #region helper methods

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Login", "Account");
            }

            return returnUrl;
        }

        #endregion
    }
}