using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using KSEPM.Common.Enums;
using KSEPM.Resources.DisplayNames;
using KSEPM.Web.Controllers.BaseControllers;
using KSEPM.Web.Database;
using KSEPM.Web.Database.Entities;
using KSEPM.Web.Infrastructure.Attributes;
using KSEPM.Web.Infrastructure.Helpers;
using KSEPM.Web.Infrastructure.Identity;
using KSEPM.Web.Models;
using KSEPM.Web.Models.ChairViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KSEPM.Web.Controllers
{
    [CustomValidateAntiForgeryToken]
    [Authorize(Roles = AccessIdentityRole.Accountant)]
    [RoutePrefix("Sell")]
    public class SellController : ManagerBaseController
    {
        private IKSEPMRepository _repository;

        public SellController(IKSEPMRepository repository)
        {
            _repository = repository;
        }

        [Route("AddSell")]
        [HttpGet]
        public ActionResult AddSell()
        {
            return View();
        }

        [Route("AddSell")]
        [HttpPost]
        public JsonResult AddChairSell(SellViewModel chairSell)
        {
            var chair = _repository.Chairs.Get(chairSell.Chair.ID);
            var chairMultiply = chair.ChairLine.ChairMultiply;
            var optionMultiply = chair.ChairLine.OptionMultiply;
            var chairOptions = chair.ChairOptions
                .Where(x => chairSell.ChairOptionIDs.Contains(x.ID) && !x.IsBasic).Select(x => x).ToList();
            var optionAmmount = chairOptions.Select(pr => pr.Price != null ? pr.Price.Value : 0).Sum();

            var overallAmmount = optionAmmount + chair.Price;
            var overallPoints = (optionAmmount * optionMultiply + chair.Price * chairMultiply) / 100;
            
            var sell = _repository.Sells.Insert(new Sell
            {
                ChairID = chairSell.Chair.ID,
                Amount = overallAmmount,
                Points = overallPoints,
                EmployeeID = chairSell.Seller.ID,
                SellPointID = chairSell.SellPoint.ID,
                SellDate = DateTimeHelper.UnixTimestampToDateTime(chairSell.SellDate),
                ChairOptions = chairOptions
            });
            chairSell.ID = sell.ID;
            chairSell.Chair.Name = chair.Name;
            chairSell.Ammount = overallAmmount;

            return Json(chairSell, JsonRequestBehavior.AllowGet);
        }

        [Route("ChairNames")]
        [HttpGet]
        public JsonResult GetChairNames()
        {
            var chairLineGrops = new List<ChairLineViewModel>();

            foreach (var chairLine in _repository.ChairLines.Get())
            {
                chairLineGrops.Add(new ChairLineViewModel
                {
                    ChairLineName = chairLine.Name,
                    Chairs = chairLine.Chairs.Select(chair => new ChairViewModel
                    {
                        ID = chair.ID,
                        Name = chair.Name
                    })
                });
            }

            return Json(chairLineGrops, JsonRequestBehavior.AllowGet);
        }

        [Route("SellerNames")]
        [HttpGet]
        public JsonResult GetSellerNames()
        {
            var sellerInfoListVM = new List<SellerViewModel>();

            foreach (var seller in GetUsersByRole(AccessIdentityRole.Employee))
            {
                sellerInfoListVM.Add(new SellerViewModel
                {
                    ID = seller.Id,
                    Name = string.Format("{0} {1}", seller.FirstName, seller.SecondName)
                });
            }

            return Json(sellerInfoListVM, JsonRequestBehavior.AllowGet);
        }

        [Route("SellPointNames")]
        [HttpGet]
        public JsonResult GetSellPointNames()
        {
            var sellPointListVM = new List<SellPointViewModel>();

            foreach (var sellPoint in _repository.SellPoints.Get())
            {
                sellPointListVM.Add(new SellPointViewModel
                {
                    ID = sellPoint.ID,
                    Name = GetLocalizatedString(sellPoint.PointName)
                });
            }

            return Json(sellPointListVM, JsonRequestBehavior.AllowGet);
        }

        [Route("ChairDetails")]
        [HttpGet]
        public JsonResult ChairDetails(int chairId)
        {
            var chair = _repository.Chairs.Get().Find(x => x.ID == chairId);

            var chairGroups = chair.ChairOptions.GroupBy(x => x.Type);

            var optionDictionary = new List<ChairOptionGroupViewModel>();
            foreach (var chairOption in chairGroups.OrderBy(x => x.Key))
            {
                if (chairOption.Count() > 1)
                {
                    optionDictionary.Add(new ChairOptionGroupViewModel
                    {
                        //if true - we can return multiple items for group
                        IsMultipleSelect = chairOption.Key == ChairOptionType.Mechanism ||
                                           chairOption.Key == ChairOptionType.Onvay,
                        ChairTypeName = GetLocalizatedString(chairOption.Key),
                        ChairOptionNames = chairOption.Select(option => new ChairOptionViewModel
                        {
                            ID = option.ID,
                            Name = GetLocalizatedString(option.Name),
                            IsBasic = option.IsBasic
                        })
                    });
                }
            }

            var model = new ChairViewModel
            {
                ChairOptionGroups = optionDictionary
            };

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [Route("TodaySells")]
        [HttpGet]
        public JsonResult GetTodaySells()
        {
            var sells = _repository.Sells.Get().Where(x => x.SellDate.ToLocalTime() >= DateTime.Now.AddDays(-1)).ToList();

            var sellInfoList = new List<SellViewModel>();

            foreach (var sell in sells)
            {
                sellInfoList.Add(new SellViewModel
                {
                    ID = sell.ID,
                    Seller = new SellerViewModel { Name = string.Format("{0} {1}", sell.Employee.FirstName, sell.Employee.SecondName) },
                    SellPoint = new SellPointViewModel { Name = GetLocalizatedString(sell.SellPoint.PointName) },
                    Chair = new ChairViewModel { Name = sell.Chair.Name },
                    ChairOptions = sell.ChairOptions.Select(x => new ChairOptionViewModel { Name = x.Name }),
                    SellDate = DateTimeHelper.DateTimeToUnixTimestamp(sell.SellDate),
                    Ammount = sell.Amount
                });
            }

            return Json(sellInfoList, JsonRequestBehavior.AllowGet);
        }

        [Route("DeleteSell")]
        [HttpGet]
        public JsonResult DeleteSell(int sellID)
        {
            _repository.Sells.Delete(_repository.Sells.Get(sellID));

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}