using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KSEPM.Web.Models.Misc
{
    public class LocalizationViewModel
    {
        public string ReturnUrl { get; set; }
        public IEnumerable<string> CultureList { get; set; }
        public string Culture { get; set; }
    }
}