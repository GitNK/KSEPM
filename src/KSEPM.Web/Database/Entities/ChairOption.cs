using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSEPM.Web.Database.Entities
{
    public class ChairOption : EntityBase
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public bool IsBasic { get; set; }

        public virtual ICollection<Chair> Chairs { get; set; }
        public virtual ICollection<Sell> Sells { get; set; } 
    }
}