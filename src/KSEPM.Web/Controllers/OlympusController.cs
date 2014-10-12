using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KSEPM.Web.Controllers.BaseControllers;

namespace KSEPM.Web.Controllers
{
    [RoutePrefix("Olympus")]
    public class OlympusController : ManagerBaseController
    {
        [HttpGet]
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }


    }
}