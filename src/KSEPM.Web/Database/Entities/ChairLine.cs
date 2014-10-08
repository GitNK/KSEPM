using System.Collections.Generic;

namespace KSEPM.Web.Database.Entities
{
    public class ChairLine : EntityBase
    {
        public string Name { get; set; }
        public double ChairMultiply { get; set; }
        public double OptionMultiply { get; set; }
        public virtual ICollection<Chair> Chairs { get; set; } 
    }
}
