using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSEPM.Web.Database.Entities;

namespace KSEPM.Web.Database.Repositories
{
    public class UserCallbackRepository : BaseRepository<UserCallback>
    {
        public UserCallbackRepository(KSEPMDbContext context)
            : base(context)
        { }
    }
}