using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSEPM.Web.Infrastructure.Identity;

namespace KSEPM.Web.Models.BaseViewModels
{
    public class AmmountBaseViewModel<T> : NameBaseViewModel<T>
    {
        private double _ammount;
        public double Ammount
        {
            get { return _ammount; }
            set
            {
                if (HttpContext.Current.User.IsInRole(AccessIdentityRole.Director))
                    _ammount = value;
            }
        }

        public double Points { get; set; }
    }
}