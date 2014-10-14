using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KSEPM.Web.Controllers.BaseControllers;
using KSEPM.Web.Database;
using KSEPM.Web.Database.Entities;
using KSEPM.Web.Database.Identity;
using KSEPM.Web.DataProcessing.Interfaces;
using KSEPM.Web.Infrastructure;
using KSEPM.Web.Infrastructure.Enums;
using KSEPM.Web.Infrastructure.Helpers;
using KSEPM.Web.Infrastructure.Identity;
using KSEPM.Web.Models;
using KSEPM.Web.Models.ChairViewModels;
using KSEPM.Web.Models.ChartViewModels;
using KSEPM.Web.Models.ChartViewModels.LinearViewModels;
using KSEPM.Web.Models.ChartViewModels.TablesViewModels;

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
        int position = 1;
        [HttpGet]
        [Route("TableInfo")]
        public JsonResult GetTableInfo(TimeInterval timespan = TimeInterval.Day)
        {
            var employees = GetUsersByRole(AccessIdentityRole.Employee).ToList();

            var employeesResults = new List<EmployeeResultViewModel>();

            foreach (var employee in employees)
            {
                var filteredSells = employee.Sells.FilterByDate(timespan);

                var ammount = filteredSells.Sum(x => x.Amount);
                var points = filteredSells.Sum(x => x.Points);
                if (filteredSells.Any())
                {
                    var selledChairsCount = filteredSells.Count;

                    employeesResults.Add(new EmployeeResultViewModel
                    {
                        Name = string.Format("{0} {1}", employee.FirstName, employee.SecondName),
                        ChairCount = selledChairsCount,
                        Ammount = ammount,
                        Points = Math.Round(points, 2)
                    });
                }
            }

            employeesResults = employeesResults.OrderByDescending(x => x.Points).ToList();
            foreach (var employee in employeesResults)
                employee.Position = position++;

            return Json(employeesResults, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("TableDetailedInfo")]
        public JsonResult GetTableDetailedInfo(TimeInterval timespan = TimeInterval.Day)
        {
            var sells = _repository.Sells.Get().OrderByDescending(x => x.SellDate).FilterByDate(timespan);

            var sellDetails = new List<SellViewModel>();
            foreach (var sell in sells)
            {
                sellDetails.Add(new SellViewModel
                {
                    Position = position++,
                    Seller = new SellerViewModel
                    {
                        Name = string.Format("{0} {1}", sell.Employee.FirstName, sell.Employee.SecondName),
                        ID = sell.EmployeeID
                    },
                    SellPoint = new SellPointViewModel
                    {
                        ID = sell.SellPoint.ID,
                        Name = GetLocalizatedString(sell.SellPoint.PointName),
                        City = GetLocalizatedString("DN_SDTVM_", sell.SellPoint.City)
                    },
                    Date = DateTimeHelper.DateTimeToUnixTimestamp(sell.SellDate),
                    Ammount = sell.Amount,
                    Points = sell.Points,
                    Achievements = "BRO!"
                });
            }
            return Json(sellDetails, JsonRequestBehavior.AllowGet);
        }

        [Route("SellPointRanking")]
        [HttpGet]
        public JsonResult GetSellPointRanking()
        {
            var sellPointRankList = new List<SellPointRankViewModel>();


            //Должно выглядеть все примерно так, если расскомитишь и запустишь, то увидишь на таблицах информацию
            //тут показана одна точка Аракс. Тебе надо их много. Используй _repository , это доступ к базе. Посмотри 
            //выше в примерах
            /*
            sellPointRankList.Add(new SellPointRankViewModel
            {
                SellPointName = "Arax",
                SelledChairCount = 20,
                SelledChairList = new List<string>
                {
                    String.Format("x{0} {1}", 10, "Diamond"),
                    String.Format("x{0} {1}", 5, "Monarch")
                },
                Ammount = 1000,
                Points = 1000
            });*/

            return Json(sellPointRankList, JsonRequestBehavior.AllowGet);
        }

        [Route("LinearCharts")]
        [HttpGet]
        public ActionResult LinearCharts()
        {
            return View();
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
                employee.ID = sellerInfo.Key.Id;
                employee.Name = sellerInfo.Key.FirstName + " " + sellerInfo.Key.SecondName;

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