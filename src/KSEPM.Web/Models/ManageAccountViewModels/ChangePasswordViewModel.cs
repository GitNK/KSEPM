using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSEPM.Web.Models.ManageAccountViewModels
{
    public class ChangePasswordViewModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}