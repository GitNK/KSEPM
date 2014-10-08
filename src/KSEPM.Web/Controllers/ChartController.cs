using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KSEPM.Web.Controllers.BaseControllers;
using KSEPM.Web.Database;
using KSEPM.Web.Database.Entities;
using KSEPM.Web.Database.Identity;
using KSEPM.Web.Infrastructure.Helpers;
using KSEPM.Web.Infrastructure.Identity;
using KSEPM.Web.Models;
using KSEPM.Web.Models.ChairViewModels;
using KSEPM.Web.Models.ChartViewModels;

namespace KSEPM.Web.Controllers
{
    [RoutePrefix("Chart")]
    public class ChartController : ManagerBaseController
    {
        private IKSEPMRepository _repository;

        public ChartController(IKSEPMRepository repository)
        {
            _repository = repository;
        }

        [Route("Tables")]
        [HttpGet]
        public ActionResult Tables()
        {
            return View();
        }

        [HttpGet]
        [Route("TableInfo")]
        public JsonResult GetTableInfo()
        {
            var employees = GetUsersByRole(AccessIdentityRole.Employee).ToList();

            var employeesResults = new List<EmployeeResultViewModel>();
            int i = 1;
            foreach (var employee in employees)
            {
                var ammount = employee.Sells.Sum(x => x.Amount);
                var points = employee.Sells.Sum(x => x.Points);

                employeesResults.Add(new EmployeeResultViewModel
                {
                    Position = i,
                    Name = string.Format("{0} {1}", employee.FirstName, employee.SecondName),
                    Ammount = ammount,
                    Points = Math.Round(points, 2)
                });
                i++;
            }

            return Json(employeesResults.OrderByDescending(x => x.Points), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("TableDetailedInfo")]
        public JsonResult GetTableDetailedInfo()
        {
            var sells = _repository.Sells.Get().OrderByDescending(x => x.SellDate).ToList();

            //var sellDetails = new List<SellDetailTableViewModel>();
            var sellDetails = new List<SellViewModel>();
            for (int i = 0; i < sells.Count; i++)
            {
                sellDetails.Add(new SellViewModel
                {
                    Position = i + 1,
                    Seller = new SellerViewModel
                    {
                        SellerName = string.Format("{0} {1}", sells[i].Employee.FirstName, sells[i].Employee.SecondName),
                        SellerID = sells[i].EmployeeID
                    },
                    SellPoint = new SellPointViewModel
                    {
                        SellPointID = sells[i].SellPoint.ID,
                        SellPointName = GetLocalizatedString(sells[i].SellPoint.PointName),
                        SellPointCity = sells[i].SellPoint.City
                    },
                    SellDate = DateTimeHelper.DateTimeToUnixTimestamp(sells[i].SellDate),
                    Ammount = sells[i].Amount,
                    Points = sells[i].Points,
                    Achievements = "BRO!"
                });
            }

            return Json(sellDetails, JsonRequestBehavior.AllowGet);
        }

        [Route("LinearCharts")]
        [HttpGet]
        public ActionResult LinearCharts()
        {
            return View();
        }


        public class LinearChartData
        {
            public IEnumerable<DateTime> Days { get; set; }
            public IEnumerable<EmployeeSellData> EmployeeSellDatas { get; set; }
        }

        public class EmployeeSellData
        {
            public string EmployeeID { get; set; }
            public string EmployeeName { get; set; }

            public IEnumerable<double> AmmountByDays { get; set; }
        }

        [Route("LastWeekSells")]
        [HttpGet]
        public JsonResult GetLastWeekSells()
        {
            var sells = _repository.Sells.Get().Where(x => x.SellDate.ToLocalTime() >= DateTime.Now.AddDays(-7)).ToList();
            foreach (var sell in sells)
                sell.SellDate = sell.SellDate.ToLocalTime();


            var sellers = GetUsersByRole(AccessIdentityRole.Employee);

            var dict = new Dictionary<ApplicationUser, IList<Sell>>();

            foreach (var seller in sellers)
            {
                dict.Add(seller, new List<Sell>());
                foreach (var sell in sells)
                    if (sell.EmployeeID == seller.Id)
                        dict[seller].Add(sell);
            }

            var dayList = new List<DateTime>
            {
                DateTime.Today,
                DateTime.Today.AddDays(-1),
                DateTime.Today.AddDays(-2),
                DateTime.Today.AddDays(-3),
                DateTime.Today.AddDays(-4),
                DateTime.Today.AddDays(-5),
                DateTime.Today.AddDays(-6)
            };

            var newDict = new Dictionary<ApplicationUser, IEnumerable<IGrouping<DateTime, Sell>>>();
            foreach (var dic in dict)
            {
                var sellByDays = (from sell in dic.Value
                                  let dt = sell.SellDate
                                  group sell by new DateTime(dt.Year, dt.Month, dt.Day) into sellDate
                                  select sellDate);
                newDict.Add(dic.Key, sellByDays);
            }


            var employeeSellData = new List<EmployeeSellData>();
            foreach (var sellerInfo in newDict)
            {
                var employee = new EmployeeSellData();
                employee.EmployeeID = sellerInfo.Key.Id;
                employee.EmployeeName = sellerInfo.Key.FirstName + " " + sellerInfo.Key.SecondName;

                var sumList = new List<double>();
                foreach (var day in dayList)
                {
                    bool hasValue = false;
                    foreach (var sellInfo in sellerInfo.Value)
                    {
                        if (day == sellInfo.Key)
                        {
                            double sum = sellInfo.Sum(x => x.Amount);
                            sumList.Add(sum);
                            hasValue = true;
                        }
                    }
                    if(!hasValue)
                        sumList.Add(0);
                }

                employee.AmmountByDays = sumList;
                employeeSellData.Add(employee);
            }


            var linearChartData = new LinearChartData
            {
                Days = dayList,
                EmployeeSellDatas = employeeSellData
            };


            return Json(linearChartData, JsonRequestBehavior.AllowGet);
        }

        [Route("PieCharts")]
        [HttpGet]
        public ActionResult PieCharts()
        {
            return View();
        }
    }
}