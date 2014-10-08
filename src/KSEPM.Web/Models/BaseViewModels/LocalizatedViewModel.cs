using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSEPM.Web.Models.BaseViewModels
{
    public class LocalizatedViewModel
    {
        private string _prefix = "DN_";
        private string _viewModelPrefix;

        public LocalizatedViewModel()
        { }

        public LocalizatedViewModel(string viewModelprefix)
        {
            _viewModelPrefix = viewModelprefix;
        }

        public LocalizatedViewModel(string viewModelprefix, string prefix)
        {
            _viewModelPrefix = viewModelprefix;
            _prefix = prefix;
        }

       // private string 
      //  public string Name
       // {
            
       // }
    }
}