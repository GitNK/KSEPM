using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSEPM.Web.Database.Identity;
using KSEPM.Web.DataProcessing.Interfaces;
using KSEPM.Web.Infrastructure.Identity;
using KSEPM.Web.Models.ChartViewModels;

namespace KSEPM.Web.DataProcessing
{
    public class DataAggregator : IDataAggregator
    {
        //public void GetTableData(ModelDataType modelData)
        //{
            
        //}

        //public IEnumerable<EmployeeResultViewModel> GetEmployeeTableData(IList<ApplicationUser> employees)
        //{
        //    var employeesResults = new List<EmployeeResultViewModel>();
        //    for (int i = 0; i < employees.Count; i++)
        //    {
        //        var ammount = employees[i].Sells.Sum(x => x.Amount);
        //        var points = employees[i].Sells.Sum(x => x.Points);
        //        var selledChairsCount = employees[i].Sells.Count;

        //        employeesResults.Add(new EmployeeResultViewModel
        //        {
        //            Name = string.Format("{0} {1}", employees[i].FirstName, employees[i].SecondName),
        //            ChairCount = selledChairsCount,
        //            Ammount = ammount,
        //            Points = Math.Round(points, 2)
        //        });
        //    }

        //    return employeesResults.OrderByDescending(x => x.Points);
        //}
    }

    //public enum ModelDataType
    //{
    //    Sell,
    //    Employee,
    //    Chair,
    //    SellPoint
    //}

    //public enum AggregationType
    //{
    //    Sum,
    //    Detailed,
    //    Avg
    //}
}