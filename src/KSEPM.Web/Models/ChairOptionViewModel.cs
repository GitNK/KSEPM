using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSEPM.Web.Models
{
    public class ChairOptionViewModel
    {
        public int ChairOptionID { get; set; }
        public string ChairOptionName { get; set; }
        public bool IsBasic { get; set; }
    }
}