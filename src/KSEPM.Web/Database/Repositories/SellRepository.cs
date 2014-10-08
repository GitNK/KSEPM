using KSEPM.Web.Database.Entities;

namespace KSEPM.Web.Database.Repositories
{
    public class SellRepository : BaseRepository<Sell>
    {
        public SellRepository(KSEPMDbContext context)
            : base(context)
        { }
    }
}