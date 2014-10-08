using KSEPM.Web.Database.Entities;

namespace KSEPM.Web.Database.Repositories
{
    public class ChairOptionRepository : BaseRepository<ChairOption>
    {
        public ChairOptionRepository(KSEPMDbContext context)
            : base(context)
        { }
    }
}