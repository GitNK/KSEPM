using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSEPM.Web.Models.BaseViewModels;

namespace KSEPM.Web.Models.ChartViewModels
{
    public class EmployeeResultViewModel : AmmountBaseViewModel<string>
    {
        public int Position { get; set; }
        public int ChairCount { get; set; }
    }
}