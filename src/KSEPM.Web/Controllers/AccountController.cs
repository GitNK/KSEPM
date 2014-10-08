using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using KSEPM.Common.Enums;
using KSEPM.Web.Controllers.BaseControllers;
using KSEPM.Web.Database;
using KSEPM.Web.Database.Identity;
using KSEPM.Web.Infrastructure.Identity;
using KSEPM.Web.Models;
using KSEPM.Web.Models.AccountViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KSEPM.Web.Controllers
{
    [Authorize(Roles = AccessIdentityRole.SubAdmin)]
    [RoutePrefix("Account")]
    public class AccountController : ManagerBaseController
    {
        [HttpGet]
        [Route("Register")]
        public ActionResult Register()
        {
            var model = new RegisterViewModel
            {
                Password = PasswordGenerator.Generate()
            };
            FillViewData();

            return View(model);
        }

        [HttpPost]
        [Route("Register")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            FillViewData();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    SecondName = model.SecondName,
                    IsActive = true,
                    Description = model.Desription,
                    PointType = model.PointType
                };

                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (model.Role != null)
                    {
                        result = await UserManager.AddToRolesAsync(user.Id, AccessIdentityRole.GetRolesByGradation(model.Role));
                        if (!result.Succeeded)
                        {
                            ModelState.AddModelError("", result.Errors.First());
                            return View(model);
                        }
                    }
                    return View("Success", model);
                }
                else
                {
                    ModelState.AddModelError("", result.Errors.First());
                }
                return View(model);
            }
            return View(model);
        }

        #region Helpers

        private void FillViewData()
        {
            IEnumerable roles = new List<IdentityRole>();
            if (User.IsInRole(AccessIdentityRole.Admin))
                roles = RoleManager.Roles.ToList();
            else if (User.IsInRole(AccessIdentityRole.SubAdmin))
                roles = RoleManager.Roles.ToList().Where(x => x.Name != AccessIdentityRole.Admin || x.Name != AccessIdentityRole.SubAdmin).ToList();

            ViewBag.RoleId = new SelectList(roles, "Name", "Name", AccessIdentityRole.Employee);

            var points = new List<SellPointTypeViewModel>();
            foreach (var pointType in SellPointType.GetAllSellPointTypes())
            {
                points.Add(new SellPointTypeViewModel
                {
                    Value = pointType,
                    Name = GetLocalizatedString("DN_RVM_", pointType)
                });
            }

            ViewBag.PointTypes = new SelectList(points, "Value", "Name");
        }
        #endregion
    }
}