using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSEPM.Web.Models.ChartViewModels.TablesViewModels
{
    public class SellPointRankViewModel
    {
        public string SellPointName { get; set; }
        public int SelledChairCount { get; set; }
        public List<string> SelledChairList { get; set; }
        public int Ammount { get; set; }
        public int Points { get; set; }
    }
}