using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSEPM.Web.App_Start;
using KSEPM.Web.Database.Identity;
using KSEPM.Web.Infrastructure.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace KSEPM.Web.Database
{
    public class IdentityDbInitializer
    {
        private static ApplicationUserManager _userManager;
        private static ApplicationRoleManager _roleManager;
        private const string AdminName = "borisermakof@gmail.com";
        private const string AdminPass = "Qwerty1111";
        private const string FirstName = "Борис";
        private const string SecondName = "Ермаков";

        public static void InitializeDb()
        {
            _userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            _roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();

            InitializeRoles();

            var admin = InitializeAdmin();

            AddRoleAdminToAdmin(admin);
        }

        private static void InitializeRoles()
        {
            //Create Role Admin if it does not exist
            foreach (var roleName in AccessIdentityRole.GetAllIdentityRoles())
            {
                var role = _roleManager.FindByName(roleName);
                if (role == null)
                {
                    role = new IdentityRole(roleName);
                    var roleresult = _roleManager.Create(role);
                    if (!roleresult.Succeeded)
                    {
                        throw new Exception("InitializeRoles");
                    }
                }
            }
        }

        private static ApplicationUser InitializeAdmin()
        {
            var user = _userManager.FindByName(AdminName);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = AdminName,
                    Email = AdminName,
                    FirstName = FirstName,
                    SecondName = SecondName,
                    IsActive = true,
                };
                var result = _userManager.Create(user, AdminPass);
                if (!result.Succeeded)
                {
                    throw new Exception("InitializeAdmin");
                }
                result = _userManager.SetLockoutEnabled(user.Id, false);
                if (!result.Succeeded)
                {
                    throw new Exception("InitializeSetLockout");
                }
            }
            return user;
        }

        private static void AddRoleAdminToAdmin(ApplicationUser admin)
        {
            // Add user admin to Role Admin if not already added
            var rolesForUser = _userManager.GetRoles(admin.Id);
            var adminRole = _roleManager.FindByName(AccessIdentityRole.Admin);
            if (!rolesForUser.Contains(adminRole.Name))
            {
                var result = _userManager.AddToRoles(admin.Id, AccessIdentityRole.GetRolesByGradation(AccessIdentityRole.Admin));
                if (!result.Succeeded)
                    throw new Exception("AddRoleAdminToAdmin");
            }
        }
    }
}