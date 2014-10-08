using System.Collections.Generic;

namespace KSEPM.Web.Database.Entities
{
    public class Chair: EntityBase
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public virtual ChairLine ChairLine { get; set; }
        public virtual ICollection<ChairOption> ChairOptions { get; set; } 
    }
}
