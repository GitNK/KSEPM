using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSEPM.Web.Models.BaseViewModels;

namespace KSEPM.Web.Models.ChartViewModels.TablesViewModels
{
    public class SellPointRankViewModel : AmmountBaseViewModel<int>
    {
        public string SellPointName { get; set; }
        public int SelledChairCount { get; set; }
        public List<string> SelledChairList { get; set; }
    }
}