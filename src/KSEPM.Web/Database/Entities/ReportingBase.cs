using System;

namespace KSEPM.Web.Database.Entities
{
    public class ReportingBase : EntityBase
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
