using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSEPM.Web.Models.BaseViewModels;

namespace KSEPM.Web.Models
{
    public class SellPointViewModel : NameBaseViewModel<int>
    {
        public string City { get; set; }
    }
}