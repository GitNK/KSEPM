using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSEPM.Web.Models.ChartViewModels.LinearViewModels
{
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
}