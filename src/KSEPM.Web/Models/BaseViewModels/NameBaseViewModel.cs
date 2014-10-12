using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSEPM.Web.Models.BaseViewModels
{ 
    public class NameBaseViewModel<T> : BaseViewModel<T>
    {
        public string Name { get; set; }
    }
}