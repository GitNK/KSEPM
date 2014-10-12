using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSEPM.Web.Models.BaseViewModels;

namespace KSEPM.Web.Models
{
    public class SellPointTypeViewModel : NameBaseViewModel<int>
    {
        public string Value { get; set; }
    }
}