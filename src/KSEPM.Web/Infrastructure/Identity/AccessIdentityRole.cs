using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSEPM.Web.Infrastructure.Identity
{
    public class AccessIdentityRole
    {
        public const string Admin = "Admin";
        public const string SubAdmin = "SubAdmin";
        public const string Accountant = "Accountant";
        public const string Director = "Director";
        public const string Employee = "Employee";

        /// <summary>
        /// ONLY FOR DB INITIALIZER!!! 
        /// </summary>
        /// <returns></returns>
        internal static IEnumerable<string> GetAllIdentityRoles()
        {
            return new List<string> { Admin, SubAdmin, Accountant, Director, Employee };
        }

        public static string[] GetRolesByGradation(string roleName)
        {
            switch (roleName)
            {
                case Admin:
                    return new[] { Admin, SubAdmin, Accountant, Director };
                case SubAdmin:
                    return new[] { SubAdmin, Accountant, Director };
                case Accountant:
                    return new[] { Accountant, Director };
                case Director:
                    return new[] { Director };
                default:
                    return new[] { Employee };
            }
        }
    }
}