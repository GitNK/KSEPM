using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSEPM.Web.Models.ChartViewModels
{
    public class EmployeeResultViewModel
    {
        public int Position { get; set; }
        public string Name { get; set; }
        public int ChairCount { get; set; }
        public double Ammount { get; set; }
        public double Points { get; set; }
    }
}