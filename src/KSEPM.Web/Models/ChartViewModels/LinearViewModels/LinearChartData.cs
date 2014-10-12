using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSEPM.Web.Models.BaseViewModels;

namespace KSEPM.Web.Models.ChartViewModels.LinearViewModels
{
    public class LinearChartData
    {
        public IEnumerable<DateTime> Days { get; set; }
        public IEnumerable<EmployeeSellData> EmployeeSellDatas { get; set; }
    }

    public class EmployeeSellData : NameBaseViewModel<string>
    {
        public IEnumerable<double> AmmountByDays { get; set; }
    }
}