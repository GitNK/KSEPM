using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSEPM.Web.Models.BaseViewModels;

namespace KSEPM.Web.Models.OlympusViewModels
{
    public class MontlyChairSellViewModel : AmmountBaseViewModel<int>
    {
        public int Position { get; set; }
        public int Count { get; set; }
    }
}