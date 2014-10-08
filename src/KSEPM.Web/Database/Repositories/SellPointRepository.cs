using KSEPM.Web.Database.Entities;

namespace KSEPM.Web.Database.Repositories
{
    public class SellPointRepository : BaseRepository<SellPoint>
    {
        public SellPointRepository(KSEPMDbContext context)
            : base(context)
        { }
    }
}