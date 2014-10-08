using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KSEPM.Web.Controllers.BaseControllers;
using KSEPM.Web.Database;
using KSEPM.Web.Infrastructure.Helpers;
using KSEPM.Web.Models.Misc;

namespace KSEPM.Web.Controllers
{
    public class HomeController : BaseController
    {
        private IKSEPMRepository _repository;
        public HomeController(IKSEPMRepository repository)
        {
            _repository = repository;

           // var chairs = repository.Chairs.Get();
        }
        // GET: Home
        [Route]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Localization")]
        public RedirectResult Localization(string cultureValue, string url)
        {
            // Validate input
            string culture = CultureHelper.GetImplementedCulture(cultureValue);
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture")
                {
                    Value = culture,
                    Expires = DateTime.Now.AddYears(1)
                };
            }
            Response.Cookies.Add(cookie);
            return Redirect(url);
        }
    }
}