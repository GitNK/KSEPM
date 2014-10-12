using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSEPM.Web.Models.BaseViewModels;

namespace KSEPM.Web.Models
{
    public class ChairOptionViewModel : NameBaseViewModel<int>
    {
        public bool IsBasic { get; set; }
    }
}