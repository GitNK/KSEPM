using System;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using KSEPM.Resources.DisplayNames;
using KSEPM.Web.Infrastructure.Helpers;
using KSEPM.Web.Models.Misc;

namespace KSEPM.Web.Controllers.BaseControllers
{
    public class BaseController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName;
            // Attempt to read the culture cookie from Request
            HttpCookie cultureCookie = Request.Cookies["_culture"];
            if (cultureCookie != null)
                cultureName = cultureCookie.Value;
            else
                cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0
                    ? Request.UserLanguages[0]
                    : // obtain it from HTTP header AcceptLanguages
                    null;
            // Validate culture name
            cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe

            // Modify current thread's cultures            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            return base.BeginExecuteCore(callback, state);
        }

        protected string GetLocalizatedString(string value)
        {
            return DisplayName.ResourceManager.GetString(String.Concat("DN_CVM_", value),
                Thread.CurrentThread.CurrentCulture);
        }

        protected string GetLocalizatedString(string prefix, string value)
        {
            return DisplayName.ResourceManager.GetString(String.Concat(prefix, value),
                Thread.CurrentThread.CurrentCulture);
        }
    }
}