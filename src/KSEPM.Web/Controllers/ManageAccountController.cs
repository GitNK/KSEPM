using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using KSEPM.Resources.Errors;
using KSEPM.Web.Controllers.BaseControllers;
using KSEPM.Web.Infrastructure.Attributes;
using KSEPM.Web.Models.ManageAccountViewModels;
using Microsoft.AspNet.Identity;

namespace KSEPM.Web.Controllers
{
    [CustomValidateAntiForgeryToken]
    [RoutePrefix("ManageAccount")]
    public class ManageAccountController : ManagerBaseController
    {
        [HttpGet]
        [Route("Employees")]
        public ActionResult Employees()
        {
            return View();
        }

        [HttpGet]
        [Route("ChangePassword")]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Route("ChangePassword")]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, false, true);
                }
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", ErrorMessage.ERR_invalid_oldpassword);
            return View(model);
        }
    }
}