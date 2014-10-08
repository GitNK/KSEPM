using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSEPM.Web.Database.Entities;

namespace KSEPM.Web.Database.Repositories
{
    public class ChairRepository : BaseRepository<Chair>
    {
        public ChairRepository(KSEPMDbContext context)
            : base(context)
        { }
    }
}