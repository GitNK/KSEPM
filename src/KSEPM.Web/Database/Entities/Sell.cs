using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using KSEPM.Web.Database.Identity;
using KSEPM.Web.Infrastructure.Attributes;
using KSEPM.Web.Infrastructure.Interfaces;

namespace KSEPM.Web.Database.Entities
{
    public class Sell : EntityBase, IDateFilter
    {
        public double Amount { get; set; }
        public double Points { get; set; }
        public DateTime SellDate { get; set; }
        public string EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual ApplicationUser Employee { get; set; }
        public int ChairID { get; set; }
        [ForeignKey("ChairID")]
        public virtual Chair Chair { get; set; }
        public int SellPointID { get; set; }
        [ForeignKey("SellPointID")]
        public virtual SellPoint SellPoint { get; set; }
        public virtual ICollection<ChairOption> ChairOptions { get; set; }
    }
}