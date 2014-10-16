using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KSEPM.Web.Controllers.BaseControllers;
using KSEPM.Web.Database;
using KSEPM.Web.Infrastructure;
using KSEPM.Web.Infrastructure.Enums;
using KSEPM.Web.Infrastructure.Identity;
using KSEPM.Web.Models.OlympusViewModels;

namespace KSEPM.Web.Controllers
{
    [Authorize(Roles = AccessIdentityRole.Director)]
    [RoutePrefix("Olympus")]
    public class OlympusController : ManagerBaseController
    {
        private IKSEPMRepository _repository;
        public OlympusController(IKSEPMRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("ChairSells")]
        public JsonResult GetChairSells(Month month = Month.Undefined)
        {
            int position = 1;
            var sells = _repository.Sells.Get().FilterByDate(month);

            var groupedChairs = sells.GroupBy(x => x.Chair.Name).OrderByDescending(x => x.Sum(y => y.Amount)).Select(x => new MontlyChairSellViewModel()
            {
                Position = position++,
                Name = x.Key,
                Count = x.Count(),
                Ammount = x.Sum(s => s.Amount),
            });

            return Json(groupedChairs, JsonRequestBehavior.AllowGet);
        }
    }
}