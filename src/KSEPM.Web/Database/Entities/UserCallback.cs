using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using KSEPM.Web.Database.Identity;

namespace KSEPM.Web.Database.Entities
{
    public class UserCallback : ReportingBase
    {  
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public ApplicationUser User { get; set; }
        public string Text { get; set; }
    }
}