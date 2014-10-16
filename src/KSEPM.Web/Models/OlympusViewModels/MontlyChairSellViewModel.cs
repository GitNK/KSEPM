using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSEPM.Web.Models.BaseViewModels;

namespace KSEPM.Web.Models.OlympusViewModels
{
    public class MontlyChairSellViewModel : NameBaseViewModel<int>
    {
        public int Position { get; set; }
        public int Count { get; set; }
        public double Ammount { get; set; }
    }
}